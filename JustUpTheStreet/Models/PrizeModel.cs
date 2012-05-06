using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustUpTheStreet.Models
{
    public class PrizeModel : IPrizeModel
    {
        public IAccount Owner
        {
            get;
            set;
        }

        public ICollection<IContribution> Contributions
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public IPrizeState State
        {
            get;
            set;
        }

        public ICollection<IRequirement> Requirements
        {
            get;
            set;
        }

        #region ISequenceIdentifer Members

        public long Id
        {
            get;
            set;
        }

        #endregion

        #region IDateAuditable Members


        public IAccount Creator
        {
            get;
            set;
        }

        public DateTime Created
        {
            get;
            set;
        }

        public DateTime LastUpdated
        {
            get;
            set;
        }

        public IAccount LastUpdater
        {
            get;
            set;
        }

        #endregion
    }// PrizeModel

    //internal interface IPrizeDataContext 
}