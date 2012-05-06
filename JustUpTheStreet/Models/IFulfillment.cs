using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace JustUpTheStreet.Models
{
    public interface IFulfillment
    {
        IRequirement SubjectRequirement { get; set; }
        string Description { get; set; }
    }
}