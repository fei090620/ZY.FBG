using System;
using System.Collections.Generic;
using ZY.FBG.Engine.Agents;

namespace ZY.FBG.Engine.Repository
{
    public class SoccerRepository : IRepository<SoccerAgent>
    {
        private SoccerRepository()
        {
            _cache = new Dictionary<string, SoccerAgent>();
        }

        private Dictionary<string, SoccerAgent> _cache;
        public static readonly SoccerRepository Instance = new SoccerRepository();
        public void Add(SoccerAgent domain)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<SoccerAgent> domainSet)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Delete(string domainId)
        {
            throw new NotImplementedException();
        }

        public void Delete(SoccerAgent domain)
        {
            throw new NotImplementedException();
        }

        public SoccerAgent Get(string domainId)
        {
            throw new NotImplementedException();
        }

        public List<SoccerAgent> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
