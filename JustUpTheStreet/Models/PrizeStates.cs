using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustUpTheStreet.Models
{
    public enum PrizeStates
    {
        Draft = 0,
        RequestForComment,
        Active,
        SolutionWindow,
        ReviewWindow,
        DisputeWindow,
        SolutionAccepted,
        UnderDispute,
        Expired,
        Completed
    }
}