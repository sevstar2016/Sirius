using System;
using System.Collections.Generic;
using System.Linq;
using BD.Models;
using SQLitePCL;

namespace MovieReviews.Database
{
    public class DbInit
    {
        public static void Initialize(MarketContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}