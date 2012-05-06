using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace JustUpTheStreet.Models
{
    public interface IClaim : IDateAuditable
    {
        IAccount Claimer { get; set; }
        ICollection<IFulfillment> RequirementsFulfilled { get; set; }
    }
}