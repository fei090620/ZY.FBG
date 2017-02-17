namespace ZY.FBG.Engine.Events
{
    public class Message
    {
        public string ID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null || !GetType().IsEquivalentTo(obj.GetType())) return false;
            var other = obj as Message;
            if (string.IsNullOrEmpty(ID) && string.IsNullOrEmpty(other.ID)) return true;
            return ID.Equals(other.ID);
        }

        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(ID) ? 0 : ID.GetHashCode();
        }
    }
}
