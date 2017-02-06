namespace ZY.FBG.Engine.Sagas
{
    public class SagaBase<TMessage> where TMessage : Message
    {
        public SagaBase()
        {
            _repository = Repository.Instance;
        }

        public string ID { get; set; }
        public Message Data { get; set; }
        protected bool _isCompleted = false;
        protected Repository _repository;
        public bool IsComplete()
        {
            return _isCompleted;
        }
    }
}
