using MVC_TDD_Test.Database;
using MVC_TDD_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TDD_Test.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext databasecontext;

        public CategoryRepository(ApplicationDbContext databasecontext)
        {
            this.databasecontext = databasecontext;
        }

        public Category GetCategoryItem(int parentid)
        {
            throw new NotImplementedException();
        }
    }
}