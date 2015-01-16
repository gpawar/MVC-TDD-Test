namespace MVC_TDD_Test.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVC_TDD_Test.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_TDD_Test.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVC_TDD_Test.Database.ApplicationDbContext context)
        {
            //Add in the roles required for the Secure Password Repository
            context.Roles.AddOrUpdate(
                r => r.Name,
                new IdentityRole { Name = "Administrator" },
                new IdentityRole { Name = "User" },
                new IdentityRole { Name = "Super User" }
            );

            context.Categories.AddOrUpdate(
                c => c.CategoryId,
                new Category { CategoryName = "Root", Deleted = false, Parent_Category = null, Category_ParentID = null }
            );
        }
    }
}
