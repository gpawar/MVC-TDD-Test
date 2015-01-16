using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_TDD_Test.Repositories;
using MVC_TDD_Test.Models;
using MVC_TDD_Test.Database;
using System.Data.Entity;
using System.Linq; 
using Moq;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using EntityFramework.Testing;
using EntityFramework.Testing.Moq;

namespace MVC_TDD_Test.Tests.Repositories
{
    [TestClass]
    public class CategoryRepositoryTests
    {
        Mock<ApplicationDbContext> mockContext;

        [TestInitialize()]
        public void Initialize()
        {
            var testcategories = new List<Category>() {
                new Category() { CategoryId = 1,  CategoryName = "Root", Category_ParentID = null, Deleted = false, CategoryOrder = 1 },
                new Category() { CategoryId = 2,  CategoryName = "Hardware", Category_ParentID = 1, Deleted = false, CategoryOrder = 1 },
                new Category() { CategoryId = 3,  CategoryName = "Software", Category_ParentID = 1, Deleted = false, CategoryOrder = 2 },
                new Category() { CategoryId = 4,  CategoryName = "Websites", Category_ParentID = 1, Deleted = false, CategoryOrder = 3 },
                new Category() { CategoryId = 5,  CategoryName = "Deleted", Category_ParentID = 1, Deleted = true, CategoryOrder = 4 },
                new Category() { CategoryId = 6,  CategoryName = "Routers", Category_ParentID = 2, Deleted = false, CategoryOrder = 1 },
                new Category() { CategoryId = 7,  CategoryName = "Switches", Category_ParentID = 2, Deleted = false, CategoryOrder = 2 },
                new Category() { CategoryId = 8,  CategoryName = "Joomla", Category_ParentID = 4, Deleted = false, CategoryOrder = 1 },
                new Category() { CategoryId = 9,  CategoryName = "Fasthosts", Category_ParentID = 4, Deleted = false, CategoryOrder = 2 },
                new Category() { CategoryId = 10,  CategoryName = "Test", Category_ParentID = 4, Deleted = true, CategoryOrder = 3 }
            }.AsQueryable();

            var testpasswords = new List<Password>() {
                new Password() { PasswordId = 1, Deleted = false, Description = "Switch 1", EncryptedUserName = "Test Username", EncryptedSecondCredential = "Test Second", EncryptedPassword = "Test Password", Location = "Test Location", Notes = "Test Notes", Parent_CategoryId = 7, PasswordOrder = 1, CreatedDate = DateTime.Now, Creator_Id = "2ebed20a-98b8-496d-8518-f42cd95507e0" },
                new Password() { PasswordId = 2, Deleted = false, Description = "Switch 2", EncryptedUserName = "Test Username", EncryptedSecondCredential = "Test Second", EncryptedPassword = "Test Password", Location = "Test Location", Notes = "Test Notes", Parent_CategoryId = 7, PasswordOrder = 2, CreatedDate = DateTime.Now, Creator_Id = "2ebed20a-98b8-496d-8518-f42cd95507e0" },
                new Password() { PasswordId = 3, Deleted = true, Description = "Switch 3", EncryptedUserName = "Test Username", EncryptedSecondCredential = "Test Second", EncryptedPassword = "Test Password", Location = "Test Location", Notes = "Test Notes", Parent_CategoryId = 7, PasswordOrder = 3, CreatedDate = DateTime.Now, Creator_Id = "2ebed20a-98b8-496d-8518-f42cd95507e0" },
            }.AsQueryable();

            var testuserpassword = new List<UserPassword>()
            {
                new UserPassword() { Id = "2ebed20a-98b8-496d-8518-f42cd95507e0", PasswordId = 1, CanViewPassword = true, CanChangePermissions = true, CanDeletePassword = true, CanEditPassword = true },
                new UserPassword() { Id = "2ebed20a-98b8-496d-8518-f42cd95507e0", PasswordId = 2, CanViewPassword = true, CanChangePermissions = true, CanDeletePassword = true, CanEditPassword = true },
                new UserPassword() { Id = "2ebed20a-98b8-496d-8518-f42cd95507e0", PasswordId = 3, CanViewPassword = true, CanChangePermissions = true, CanDeletePassword = true, CanEditPassword = true },
                new UserPassword() { Id = "11111111-98b8-496d-8518-f42cd95507e0", PasswordId = 1, CanViewPassword = true, CanChangePermissions = false, CanDeletePassword = true, CanEditPassword = true },
                new UserPassword() { Id = "11111111-98b8-496d-8518-f42cd95507e0", PasswordId = 2, CanViewPassword = true, CanChangePermissions = true, CanDeletePassword = false, CanEditPassword = false }
            }.AsQueryable();

            var testroles = new List<IdentityRole>()
            {
                new IdentityRole() { Id = "1", Name = "Administrator" },
                new IdentityRole() { Id = "2", Name = "User" }
            }.AsQueryable();

            var testidentities = new List<ApplicationUser>()
            {
                new ApplicationUser() { Id = "2ebed20a-98b8-496d-8518-f42cd95507e0", UserName = "TestUser", userFullName = "Test User", isActive = true, isAuthorised = true, Email = "davie@recallhosting.co.uk", PasswordHash  = "AIxwFq/H7sElYxlMwJiiS2aiYLrU0BBT/el/EDaSZRpAP2/bkuMDIbqWdA+LIlaF3A==", SecurityStamp = "186e0156-3125-4fe2-a806-37f49d949b34", LockoutEnabled = true },
                new ApplicationUser() { Id = "11111111-98b8-496d-8518-f42cd95507e0", UserName = "TestUser2", userFullName = "Test User 2", isActive = true, isAuthorised = true, Email = "davie@thatcoderguy.co.uk", PasswordHash  = "AIxwFq/H7sElYxlMwJiiS2aiYLrU0BBT/el/EDaSZRpAP2/bkuMDIbqWdA+LIlaF3A==", SecurityStamp = "186e0156-3125-4fe2-a806-37f49d949b34", LockoutEnabled = true }
            }.AsQueryable();

            var mockCategorySet = new Mock<DbSet<Category>>();
            mockCategorySet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(testcategories.Provider);
            mockCategorySet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(testcategories.Expression);
            mockCategorySet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(testcategories.ElementType);
            mockCategorySet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(testcategories.GetEnumerator());

            var mockPasswordSet = new Mock<DbSet<Password>>();
            mockPasswordSet.As<IQueryable<Password>>().Setup(m => m.Provider).Returns(testpasswords.Provider);
            mockPasswordSet.As<IQueryable<Password>>().Setup(m => m.Expression).Returns(testpasswords.Expression);
            mockPasswordSet.As<IQueryable<Password>>().Setup(m => m.ElementType).Returns(testpasswords.ElementType);
            mockPasswordSet.As<IQueryable<Password>>().Setup(m => m.GetEnumerator()).Returns(testpasswords.GetEnumerator());

            var mockUserPasswordSet = new Mock<DbSet<UserPassword>>();
            mockUserPasswordSet.As<IQueryable<UserPassword>>().Setup(m => m.Provider).Returns(testuserpassword.Provider);
            mockUserPasswordSet.As<IQueryable<UserPassword>>().Setup(m => m.Expression).Returns(testuserpassword.Expression);
            mockUserPasswordSet.As<IQueryable<UserPassword>>().Setup(m => m.ElementType).Returns(testuserpassword.ElementType);
            mockUserPasswordSet.As<IQueryable<UserPassword>>().Setup(m => m.GetEnumerator()).Returns(testuserpassword.GetEnumerator());

            var mockRoleSet = new Mock<DbSet<IdentityRole>>();
            mockRoleSet.As<IQueryable<IdentityRole>>().Setup(m => m.Provider).Returns(testroles.Provider);
            mockRoleSet.As<IQueryable<IdentityRole>>().Setup(m => m.Expression).Returns(testroles.Expression);
            mockRoleSet.As<IQueryable<IdentityRole>>().Setup(m => m.ElementType).Returns(testroles.ElementType);
            mockRoleSet.As<IQueryable<IdentityRole>>().Setup(m => m.GetEnumerator()).Returns(testroles.GetEnumerator());

            var mockUserSet = new Mock<DbSet<ApplicationUser>>();
            mockUserSet.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(testidentities.Provider);
            mockUserSet.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(testidentities.Expression);
            mockUserSet.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(testidentities.ElementType);
            mockUserSet.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(testidentities.GetEnumerator());

            mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Categories).Returns(mockCategorySet.Object);
            mockContext.Setup(c => c.Passwords).Returns(mockPasswordSet.Object);
            mockContext.Setup(c => c.UserPasswords).Returns(mockUserPasswordSet.Object);
            mockContext.Setup(c => c.Roles).Returns(mockRoleSet.Object);
            mockContext.Setup(c => c.Users).Returns(mockUserSet.Object);

            //https://github.com/rowanmiller/EntityFramework.Testing
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void TestInstantiation()
        {
            ICategoryRepository repository = new CategoryRepository(mockContext.Object);
            Assert.IsNotNull(repository);
            Assert.IsInstanceOfType(repository,typeof(CategoryRepository));
        }

        [TestMethod]
        public void TestGetCategoryItem()
        {
            ICategoryRepository repository = new CategoryRepository(mockContext.Object);
            Category item = repository.GetCategoryItem(1);
            Assert.AreEqual(3, item.SubCategories.Count);
        }
    }
}
