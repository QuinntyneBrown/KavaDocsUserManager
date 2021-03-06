﻿using System;
using System.Collections.Generic;
using System.Text;
using KavaDocsUserManager.Business.Configuration;
using KavaDocsUserManager.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace KavaDocsUserManager.Business.Tests
{
    public class TestHelper
    {
        public static string ConnectionString { get; set; } = "server=.;database=KavaDocs;integrated security=true;";

        //public static string ConnectionString { get; set; } = "Server=tcp:kavadocs.database.windows.net,1433;Initial Catalog=kavadocs;Persist Security Info=False;User ID=kavadocs;Password=McbhhUA0FMddt9Qmz77Ogb2A4eiL8F;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static KavaDocsConfiguration Configuration { get; set; } = KavaDocsConfiguration.Current;
        
        public static Guid UserId1 { get; set; } = new Guid("11111111-0589-4951-ad11-dae7fb1566cb");
        public static Guid UserId2 { get; set; } = new Guid("22222222-0589-4951-ad11-dae7fb1566cb");

        public static KavaDocsContext GetContext()
        {
            var options = new DbContextOptionsBuilder<KavaDocsContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            var ctx = new KavaDocsContext(options);
            DatabaseCreator.EnsureKavaDocsData(ctx);
            return ctx;
        }
        

        public static UserBusiness GetUserBusiness()
        {
            return  new UserBusiness(GetContext(), KavaDocsConfiguration.Current);
        }

        public static RepositoryBusiness GetRepositoryBusiness()
        {
            return new RepositoryBusiness(GetContext(), KavaDocsConfiguration.Current);
        }

        public static OrganizationBusiness GetOrganizationBusiness()
        {
            return new OrganizationBusiness(GetContext(), KavaDocsConfiguration.Current);
        }
    }
}
