using ZY.FBG.Engine.Sagas;

namespace ZY.FBG.Engine.Agents
{
    /// <summary>
    /// 球队Agent
    /// </summary>
    public class TeamAgent : DomainObject
    {
        private TeamAgent()
        {
        }

        public static TeamAgent CreateNew(string id, string playGroundID )
        {
            TeamAgent team = new TeamAgent
            {
                ID = id,
                Grades = 0,
                PlayGroundID = playGroundID
            };

            return team;
        }

        public void AddToGetGoalEvent()
        {
            var playGround = Repository.Instance.GetById(PlayGroundID);
            if (!(playGround is PlayGroundAgent)) return;

            (playGround as PlayGroundAgent).OnTeamAScore += TeamGetSocre;
            (playGround as PlayGroundAgent).OnTeamBScore += TeamGetSocre;
        }

        private void TeamGetSocre(object sender, TeamGetGoalEventArgs e)
        {
            if (e.TeamID.Equals(ID))
                Grades++;
        }

        public string PlayGroundID { get; private set; }
        public int Grades { get; private set; }
    }
}
