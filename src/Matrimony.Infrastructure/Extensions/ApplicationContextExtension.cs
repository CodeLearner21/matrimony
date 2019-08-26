using Matrimony.Infrastructure.Data.Entities;
using Matrimony.Infrastructure.Data.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrimony.Infrastructure.Extensions
{
    public static class ApplicationContextExtension
    {
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this ApplicationDbContext context)
        {

            // Default Portfolio types
            List<PortfolioType> portfolioTypes = new List<PortfolioType>
            {
                new PortfolioType { Name = "Self" },
                new PortfolioType { Name = "Son" },
                new PortfolioType { Name = "Doughter" },
                new PortfolioType { Name = "Brother" },
                new PortfolioType { Name = "Sister" },
                new PortfolioType { Name = "Relative" }
            };
            context.PortfolioTypes.AddRange(portfolioTypes);
            context.SaveChanges();

            // Default user
            var testUser = new AppUser
            {
                UserName = "test123",
                FirstName = "test",
                LastName = "demo",
                Email = "test@demo.com",
                PasswordHash = "Test+123456"
            };
            
            // Default portfolio
            var portfolio = new Portfolio
            {
                ProfileName = string.Format("{0} {1}", testUser.FirstName, testUser.LastName),                
                PortfolioTypeId = portfolioTypes.FirstOrDefault().Id            
            };
            context.Portfolios.Add(portfolio);
            testUser.Portfolio = portfolio;
            context.Users.Add(testUser);
            context.SaveChanges();
        }
    }
}
