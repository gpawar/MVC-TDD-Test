using Microsoft.AspNet.Identity.EntityFramework;
using MVC_TDD_Test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_TDD_Test.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual IDbSet<Password> Passwords { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<UserPassword> UserPasswords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //setup foreign key relationships

            modelBuilder.Entity<Category>()
                .HasRequired(a => a.Parent_Category)
                .WithMany(b => b.SubCategories)
                .HasForeignKey(c => c.Category_ParentID) // FK_Category_ParentID
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Password>()
                .HasRequired(a => a.Parent_Category)
                .WithMany(b => b.Passwords)
                .HasForeignKey(c => c.Parent_CategoryId) // FK_Parent_CategoryId
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Password>()
                .HasRequired(a => a.Creator)
                .WithMany(b => b.Passwords)
                .HasForeignKey(c => c.Creator_Id) // FK_Creator_Id
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserPassword>()
                .HasRequired(a => a.UsersPassword)
                .WithMany(b => b.Parent_UserPasswords)
                .HasForeignKey(c => c.PasswordId)
                .WillCascadeOnDelete(false);

        }
    }
}