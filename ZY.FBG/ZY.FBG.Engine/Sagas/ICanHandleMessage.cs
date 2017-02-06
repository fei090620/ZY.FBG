namespace ZY.FBG.Engine.Sagas
{
    public interface ICanHandleMessage<TMessage> 
        where TMessage : Message
    {
        void Handle(TMessage message);
    }
}
