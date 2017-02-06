using System;
using System.Collections.Generic;

namespace ZY.FBG.Engine.Sagas
{
    public class Bus
    {
        private static readonly Dictionary<Type, Type> SagaStarters 
            = new Dictionary<Type, Type>();
        private static readonly Dictionary<string, object> SagaInstance 
            = new Dictionary<string, object>();

        public static void RegesteSaga<TStartMessage, TSaga>()
        {
            if (SagaStarters.ContainsKey(typeof(TStartMessage)))
                return;
            
            SagaStarters.Add(typeof(TStartMessage), typeof(TSaga));
        }

        public static void Send<TMessage>(TMessage message)
            where TMessage : Message
        {
            //遍历所有已注册的saga
            //让他们有机会处理这个事件
            if (message is IDomentEvent)
            {
                foreach (var saga in SagaInstance)
                {
                    var handler = saga as ICanHandleMessage<TMessage>;
                    if (handler != null)
                        handler.Handle(message);
                }
            }

            //判断这个消息能否启动其中一个已经注册的saga
            if (SagaStarters.ContainsKey(typeof(TMessage)))
            {
                //启动saga，并处理消息
                var typeOfSaga = SagaStarters[typeof(TMessage)];
                dynamic instance = Activator.CreateInstance(typeOfSaga);

                //启动后保存saga实例，后续备用
                SagaInstance.Add(message.ID, instance);
                instance.Handle(message);

                return;
            }

            //该消息不启动任何saga
            //判断该消息能否传给现有的saga
            if (SagaInstance.ContainsKey(message.ID))
            {
                dynamic saga = SagaInstance[message.ID];
                saga.Handle(message);

                //完成后保存或者移除saga
                if (saga.IsComplete())
                {
                    SagaInstance.Remove(message.ID);
                }
                else
                    SagaInstance[message.ID] = saga;
            }
        }
    }
}
