namespace ZY.FBG.Engine.Sagas
{
    public interface IStartWithMessage<TMessage> where TMessage : Message
    {
        void Handle(TMessage message);
    }
}
