using System;
using System.Collections.Generic;
using ZY.FBG.Engine.Agents;

namespace ZY.FBG.Engine.Repository
{
    public class PlayerReposority : IRepository<PlayerAgent>
    {
        private PlayerReposority()
        {
            _cache = new Dictionary<string, PlayerAgent>();
        }
        private Dictionary<string, PlayerAgent> _cache;
        public static readonly PlayerReposority Instance = new PlayerReposority();

        public void Add(PlayerAgent domain)
        {
            throw new NotImplementedException();
        }

        public void Delete(PlayerAgent domain)
        {
            throw new NotImplementedException();
        }

        public void Delete(string domainId)
        {
            throw new NotImplementedException();
        }

        public List<PlayerAgent> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<PlayerAgent> domainSet)
        {
            throw new NotImplementedException();
        }

        public PlayerAgent Get(string domainId)
        {
            throw new NotImplementedException();
        }
    }
}
