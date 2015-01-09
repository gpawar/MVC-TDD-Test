using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MVC_TDD_Test.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string userPrivateKey { get; set; }
        public string userPublicKey { get; set; }
        public string userEncryptionKey { get; set; }
        public string userFullName { get; set; }
        [Display(Name = "Account authorised by Admin")]
        public bool isAuthorised { get; set; }
        public DateTime? userLastEncryptionKeyUpdate { get; set; }
        public virtual ICollection<UserPassword> UserPasswords { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }
        public bool isActive { get; set; }

    }
}