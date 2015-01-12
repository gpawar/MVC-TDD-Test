using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_TDD_Test.Repositories;
using MVC_TDD_Test.Models;
using MVC_TDD_Test.Database;
using Moq;
using System.Collections.Generic;

namespace MVC_TDD_Test.Tests.Repositories
{
    [TestClass]
    public class CategoryRepositoryTests
    {
        Mock<ApplicationDbContext> context;

        [TestInitialize()]
        public void Initialize()
        {
            List<Category> testcategories = new List<Category>() {
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
            };

            List<Password> testpasswords = new List<Password>() {
                new Password() { PasswordId = 1, Deleted = false, Description = "Switch 1", EncryptedUserName = "Test Username", EncryptedSecondCredential = "Test Second", EncryptedPassword = "Test Password", Location = "Test Location", Notes = "Test Notes", Parent_CategoryId = 7, PasswordOrder = 1, CreatedDate = DateTime.Now, Creator_Id = "2ebed20a-98b8-496d-8518-f42cd95507e0" },
                new Password() { PasswordId = 2, Deleted = false, Description = "Switch 2", EncryptedUserName = "Test Username", EncryptedSecondCredential = "Test Second", EncryptedPassword = "Test Password", Location = "Test Location", Notes = "Test Notes", Parent_CategoryId = 7, PasswordOrder = 2, CreatedDate = DateTime.Now, Creator_Id = "2ebed20a-98b8-496d-8518-f42cd95507e0" },
                new Password() { PasswordId = 3, Deleted = true, Description = "Switch 3", EncryptedUserName = "Test Username", EncryptedSecondCredential = "Test Second", EncryptedPassword = "Test Password", Location = "Test Location", Notes = "Test Notes", Parent_CategoryId = 7, PasswordOrder = 3, CreatedDate = DateTime.Now, Creator_Id = "2ebed20a-98b8-496d-8518-f42cd95507e0" },
            };

            context = new Mock<ApplicationDbContext>();
            
        }

        [TestCleanup()]
        public void Cleanup()
        {
            
        }

        [TestMethod]
        public void TestInstantiation()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            ICategoryRepository repository = new CategoryRepository(context);
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void TestGetCategoryItem()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            

            ICategoryRepository repository = new CategoryRepository(context);
            Category item = repository.GetCategoryItem(1);

        }
    }
}
