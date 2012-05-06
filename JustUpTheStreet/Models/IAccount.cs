using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace JustUpTheStreet.Models
{
    public interface IAccount : IDateAuditable, ISequenceIdentifer
    {
        string UserName { get; set; }
        string DisplayName { get; set; }
    }
}