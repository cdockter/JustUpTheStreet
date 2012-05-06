using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;
using System.Data.Entity;
using System.Data.Linq.Mapping;
using JustUpTheStreet.Models;

namespace SyncDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new DataContext(@"C:\repository\JustUpTheStreet\JustUpTheStreet\App_Data\JustUpTheStreet.mdf");
            database.Database.Create();
        }
    }
}
