namespace ZY.FBG.Engine.Events
{
    public interface IStartWithMessage<TMessage> where TMessage : Message
    {
        void Handle(TMessage message);
    }
}
