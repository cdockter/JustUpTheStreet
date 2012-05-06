using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client.Document;
using System.Web.SessionState;
using JustUpTheStreet.Models;
using JustUpTheStreet.Models.DataContexts;

namespace JustUpTheStreet
{
    public class ContextControllerActivator : IControllerActivator
    {
        private readonly object m_dataConfig;

        public ContextControllerActivator(object dataConfig)
        {
            m_dataConfig = dataConfig;
        }

        #region IControllerActivator Members

        IController IControllerActivator.Create(RequestContext requestContext, Type controllerType)
        {
            var controller = (IController)null;
            var context = (IDataContext) new MsSqlDataContext(m_dataConfig);
            var contructor = controllerType.GetConstructor( new Type[] { typeof(IDataContext) } );
            if(contructor != null)
            {
                controller = (IController)contructor.Invoke(new object[] { context });
            }
            else
            {
                controller = (IController)Activator.CreateInstance(controllerType);
            }
            return controller;
        }

        #endregion
    }
}