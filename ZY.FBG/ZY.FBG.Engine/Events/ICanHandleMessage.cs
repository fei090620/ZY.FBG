namespace ZY.FBG.Engine.Events
{
    public interface ICanHandleMessage<TMessage> 
        where TMessage : Message
    {
        void Handle(TMessage message);
    }
}
