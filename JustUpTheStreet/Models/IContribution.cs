using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace JustUpTheStreet.Models
{
    public interface IContribution : IDateAuditable
    {
        IAccount Contributor { get; set; }
        double Amount { get; set; }
        DateTime ExpirationDate { get; set; }

    }
}