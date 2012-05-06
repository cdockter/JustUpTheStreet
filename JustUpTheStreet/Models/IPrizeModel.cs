using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace JustUpTheStreet.Models
{
    public interface IPrizeModel : IDateAuditable, ISequenceIdentifer
    {
        IAccount Owner { get; set; }
        ICollection<IContribution> Contributions { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IPrizeState State { get; set; }
        ICollection<IRequirement> Requirements { get; set; }
    }
}