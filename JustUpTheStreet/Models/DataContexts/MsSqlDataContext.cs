using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Raven.Client.Document;
using Raven.Client;
using JustUpTheStreet.Models.DataContexts;
using System.Data.EntityClient;

namespace JustUpTheStreet.Models.DataContexts
{
    public class MsSqlDataContext : IDataContext
    {
        private readonly MsSqlDataContextContainer m_dataContainor;

        public MsSqlDataContext()
        {
            m_dataContainor = new MsSqlDataContextContainer();
        }

        public MsSqlDataContext(object dataConfig)
        {
            var builder = new EntityConnectionStringBuilder();
            m_dataContainor = new MsSqlDataContextContainer(dataConfig as string);
        }

        #region IDataContext Members

        public IQueryable<Account> Accounts
        {
            get { return m_dataContainor.Accounts; }
        }

        public IQueryable<Claim> Claims
        {
            get { return m_dataContainor.Claims; }
        }

        public IQueryable<Contribution> Contributions
        {
            get { return m_dataContainor.Contributions; }
        }

        public IQueryable<Fulfillment> Fulfillments
        {
            get { return m_dataContainor.Fulfillments; }
        }

        public IQueryable<Prize> Prizes
        {
            get { return m_dataContainor.Prizes; }
        }

        public IQueryable<Requirement> Requirements
        {
            get { return m_dataContainor.Requirements; }
        }

        public void Add<T>(T toAdd)
        {
            var type = toAdd.GetType();

            if(typeof(Account) == type)
            {
                m_dataContainor.Accounts.AddObject(toAdd as Account);
            }
            else if(typeof(Claim) == type)
            {
                m_dataContainor.Claims.AddObject(toAdd as Claim);
            }
            else if(typeof(Contribution) == type)
            {
                m_dataContainor.Contributions.AddObject(toAdd as Contribution);
            }
            else if(typeof(Fulfillment) == type)
            {
                m_dataContainor.Fulfillments.AddObject(toAdd as Fulfillment);
            }
            else if(typeof(Prize) == type)
            {
                m_dataContainor.Prizes.AddObject(toAdd as Prize);
            }
            else if(typeof(Requirement) == type)
            {
                m_dataContainor.Requirements.AddObject(toAdd as Requirement);
            }
            else
            {
                throw new ArgumentException("toAdd");
            }
        }

        public void Delete<T>(T toDelete)
        {
            var type = toDelete.GetType();

            if(typeof(Account) == type)
            {
                m_dataContainor.Accounts.DeleteObject(toDelete as Account);
            }
            else if(typeof(Claim) == type)
            {
                m_dataContainor.Claims.DeleteObject(toDelete as Claim);
            }
            else if(typeof(Contribution) == type)
            {
                m_dataContainor.Contributions.DeleteObject(toDelete as Contribution);
            }
            else if(typeof(Fulfillment) == type)
            {
                m_dataContainor.Fulfillments.DeleteObject(toDelete as Fulfillment);
            }
            else if(typeof(Prize) == type)
            {
                m_dataContainor.Prizes.DeleteObject(toDelete as Prize);
            }
            else if(typeof(Requirement) == type)
            {
                m_dataContainor.Requirements.DeleteObject(toDelete as Requirement);
            }
            else
            {
                throw new ArgumentException("toDelete");
            }
        }

        public void Commit()
        {
            m_dataContainor.SaveChanges();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            m_dataContainor.Dispose();
        }

        #endregion
    }
}