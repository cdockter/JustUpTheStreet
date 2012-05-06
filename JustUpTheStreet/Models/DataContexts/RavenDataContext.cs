using System;
using System.Linq;
using Raven.Client;
using Raven.Client.Document;

namespace JustUpTheStreet.Models.DataContexts
{
    public class RavenDataContext : IDataContext
    {
        public RavenDataContext(DocumentStore dataStore)
        {
            m_store = dataStore;
            m_session = m_store.OpenSession();
        }

        private readonly DocumentStore m_store;
        private readonly IDocumentSession m_session;

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            m_session.Dispose();
        }

        #endregion

        #region IDataContext Members

        public IQueryable<Account> Accounts
        {
            get { return m_session.Query<Account>(); }
        }

        public IQueryable<Claim> Claims
        {
            get { return m_session.Query<Claim>(); }
        }

        public IQueryable<Contribution> Contributions
        {
            get { return m_session.Query<Contribution>(); }
        }

        public IQueryable<Fulfillment> Fulfillments
        {
            get { return m_session.Query<Fulfillment>(); }
        }

        public IQueryable<Prize> Prizes
        {
            get { return m_session.Query<Prize>(); }
        }

        public IQueryable<Requirement> Requirements
        {
            get { return m_session.Query<Requirement>(); }
        }

        public void Add<T>(T toAdd)
        {
            m_session.Store(toAdd);
        }

        public void Delete<T>(T toDelete)
        {
            m_session.Delete(toDelete);
        }

        public void Commit()
        {
            m_session.SaveChanges();
        }

        #endregion
    }// DataContext
}