using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace JustUpTheStreet.Models
{
    public interface ISequenceIdentifer
    {
        [Column(IsPrimaryKey=true)]
        long Id { get; set; }
    }

    public interface IDateAuditable
    {
        DateTime Created { get; set; }
        DateTime LastUpdated { get; set; }
        IAccount Creator { get; set; }
        IAccount LastUpdater { get; set; }
    }
}//JustUpTheStreet