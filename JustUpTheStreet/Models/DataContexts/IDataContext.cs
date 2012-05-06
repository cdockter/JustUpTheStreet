using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustUpTheStreet.Models.DataContexts
{
    public interface IDataContext : IDisposable
    {
        IQueryable<Account> Accounts { get; }
        IQueryable<Claim> Claims { get; }
        IQueryable<Contribution> Contributions { get; }
        IQueryable<Fulfillment> Fulfillments { get; }
        IQueryable<Prize> Prizes { get; }
        IQueryable<Requirement> Requirements { get; }
        void Add<T>(T toAdd);
        void Delete<T>(T toDelete);
        void Commit();
    }
}