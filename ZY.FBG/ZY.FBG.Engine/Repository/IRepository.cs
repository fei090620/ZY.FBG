using System.Collections.Generic;
using ZY.FBG.Engine.Agents;

namespace ZY.FBG.Engine.Repository
{
    public interface IRepository<TDomain> where TDomain : IAggregateRoot
    { 
        TDomain Get(string domainId);
        void Add(TDomain domain);
        void Delete(TDomain domain);
        void Delete(string domainId);
        List<TDomain> GetAll();
        void Clear();
        void AddRange(IEnumerable<TDomain> domainSet);
    }
}
