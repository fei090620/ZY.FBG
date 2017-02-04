namespace ZY.FBG.Engine.Agents
{
    public interface IDomian
    {
        string Id { get; }
    }

    public class Domain : IDomian
    {
        public string Id { get; protected set; }
        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj == null || !GetType().IsEquivalentTo(obj.GetType()))
                return false;

            var other = obj as Domain;
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(Id))
                return 0;

            return Id.GetHashCode();
        }
    }
}
