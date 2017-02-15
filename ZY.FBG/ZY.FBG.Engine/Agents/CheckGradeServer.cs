namespace ZY.FBG.Engine.Agents
{
    public sealed class CheckGradeServer
    {
        private CheckGradeServer()
        {
            GameEngine.Instance.OnGameTimeChanged += Instance_OnGameTimeChanged;
        }

        private void Instance_OnGameTimeChanged(object sender, Events.GameTimeEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public static readonly CheckGradeServer Instance = new CheckGradeServer();
        public void InitialSoccerID(string soccerID)
        {
            _soccerID = soccerID;
        }

        public void InitialPlayGroundID(string playGroundID)
        {
            _playerGroundID = playGroundID;
        }

        public void InitialTeamIDs(string teamAId, string teamBId)
        {
            _teamAId = teamAId;
            _teamBId = teamBId;
        }

        private string _soccerID;
        private string _playerGroundID;
        private string _teamAId;
        private string _teamBId;
    }
}
