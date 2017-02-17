using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public static TeamAgent CreateNew(string id, string teamName, IEnumerable<PlayerAgent> players)
        {
            TeamAgent team = new TeamAgent
            {
                ID = id,
                Grades = 0,
                TeamName = teamName,
                Players = players == null ? new List<PlayerAgent>() : players.ToList() 
            };

            return team;
        }

        public void TeamGetSocre()
        {
            Grades++;
            Debug.WriteLine("当前{0}队得分为：{1}",ID, Grades);
        }

        public string TeamName { get; private set; }
        public int Grades { get; private set; }

        public List<PlayerAgent> Players { get; private set; }
    }
}
