using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustUpTheStreet.Models;
using JustUpTheStreet.Models.DataContexts;

namespace JustUpTheStreet.Controllers
{
    public class PrizeController : Controller, IDisposable
    {
        private readonly IDataContext m_context;
        private IDataContext Context { get { return m_context; } }

        public PrizeController(IDataContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context");
            }
            m_context = context;
        }

        //
        // GET: /Prize/

        public ActionResult Index()
        {
            var accounts = Context.Accounts.Where(p => p.State != (int)AccountState.Deleted);
            return View(accounts);
        }

        //
        // GET: /Prize/Details/5

        public ActionResult Details(long id)
        {
            var account = Context.Accounts.SingleOrDefault(p => p.Id == id);
            return View(account);
        }

        //
        // GET: /Prize/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Prize/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var account = new Account();
                account.AccountName = collection["AccountName"];
                account.DisplayName = collection["DisplayName"];
                account.State = (int)AccountState.Active;
                Context.Add(account);
                Context.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Prize/Edit/5
 
        public ActionResult Edit(long id)
        {
            var account = Context.Accounts.SingleOrDefault(p => p.Id == id);
            return View(account);
        }

        //
        // POST: /Prize/Edit/5

        [HttpPost]
        public ActionResult Edit(long id, FormCollection collection)
        {
            try
            {
                var account = Context.Accounts.Single(x => x.Id == id);
                account.AccountName = collection["AccountName"];
                account.DisplayName = collection["DisplayName"];
                Context.Commit();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Prize/Delete/5

        public ActionResult Delete(long id)
        {
            var account = Context.Accounts.SingleOrDefault(p => p.Id == id);
            return View(account);
        }

        //
        // POST: /Prize/Delete/5

        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                var account = Context.Accounts.SingleOrDefault(p => p.Id == id);
                account.State = (int)AccountState.Deleted;
                Context.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            Context.Dispose();
        }

        #endregion
    }
}
