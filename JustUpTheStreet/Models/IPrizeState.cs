using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace JustUpTheStreet.Models
{
    public interface IPrizeState
    {
        PrizeStates State { get; set; }
        DateTime ExpirationDate { get; set; }
    }
}