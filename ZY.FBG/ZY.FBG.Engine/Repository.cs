using System.Collections.Generic;
using ZY.FBG.Engine.Agents;

namespace ZY.FBG.Engine.Sagas
{
    public class Repository
    {
        protected Repository() { }
        public static readonly Repository Instance = new Repository();
        private Dictionary<string, SoccerAgent> _soccers 
            = new Dictionary<string, SoccerAgent>();
        private Dictionary<string, PlayerAgent> _players 
            = new Dictionary<string, PlayerAgent>();
        private Dictionary<string, TeamAgent> _teams 
            = new Dictionary<string, TeamAgent>();

        public DomainObject GetById(string id)
        {
            if (_soccers.ContainsKey(id))
                return _soccers[id];

            if (_players.ContainsKey(id))
                return _players[id];

            if (_teams.ContainsKey(id))
                return _teams[id];

            return null;
        }

        public void Save(DomainObject domainObject)
        {
            if (domainObject == null)
                return;

            if (domainObject is SoccerAgent 
                && !_soccers.ContainsKey(domainObject.ID))
                _soccers.Add(domainObject.ID, domainObject as SoccerAgent);

            if (domainObject is PlayerAgent 
                && !_players.ContainsKey(domainObject.ID))
                _players.Add(domainObject.ID, domainObject as PlayerAgent);

            if (domainObject is TeamAgent && !_teams.ContainsKey(domainObject.ID))
                _teams.Add(domainObject.ID, domainObject as TeamAgent);
        }

        public void Update(DomainObject newDomainObject)
        {
            if (newDomainObject == null)
                return;

            if (newDomainObject is SoccerAgent
                && _soccers.ContainsKey(newDomainObject.ID))
                _soccers[newDomainObject.ID] = newDomainObject as SoccerAgent;

            if (newDomainObject is PlayerAgent
                && _players.ContainsKey(newDomainObject.ID))
                _players[newDomainObject.ID] = newDomainObject as PlayerAgent;

            if (newDomainObject is TeamAgent
                && _teams.ContainsKey(newDomainObject.ID))
                _teams[newDomainObject.ID] = newDomainObject as TeamAgent;
        }
    }
}
