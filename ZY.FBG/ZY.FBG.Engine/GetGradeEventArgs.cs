namespace ZY.FBG.Engine
{
    public class GetGradeEventArgs : GameTimeEventArgs
    {
        public GetGradeEventArgs(string gameTime, string getGradeTeamId) : base(gameTime)
        {
            GetGradeTeamID = getGradeTeamId;
        }

        public string GetGradeTeamID { get; private set; }

        public override bool Equals(object obj)
        {
            //?
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            //?
            return base.GetHashCode();
        }
    }
}
