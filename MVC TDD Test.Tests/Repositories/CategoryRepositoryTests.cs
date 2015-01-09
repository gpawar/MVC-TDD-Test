using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_TDD_Test.Repositories;
using MVC_TDD_Test.Models;
using MVC_TDD_Test.Database;

namespace MVC_TDD_Test.Tests.Repositories
{
    [TestClass]
    public class CategoryRepositoryTests
    {
        [TestMethod]
        public void TestInstantiation()
        {
            ICategoryRepository repository = new CategoryRepository();
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
