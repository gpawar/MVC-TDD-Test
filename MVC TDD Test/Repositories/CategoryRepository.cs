using MVC_TDD_Test.Database;
using MVC_TDD_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//using EntityFramework.Testing.Moq;

namespace MVC_TDD_Test.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext databasecontext;

        public CategoryRepository(ApplicationDbContext databasecontext)
        {
            this.databasecontext = databasecontext;
        }

        public IQueryable<Category> GetItem(int parentcategoryid)
        {
            return databasecontext.Categories.Where(c => c.CategoryId == parentcategoryid);
        }

        public Category GetPopulatedItem(IQueryable<Category> item)
        {
            var CategoryItem = item.Include("SubCategories").Single(i => i.CategoryId == 1);
            return CategoryItem;
        }

        public Category GetCategoryItem(int parentcategoryid)
        {
            //return the selected item - with its children
            var CategoryItem = databasecontext.Categories
                                                        .Where(c => c.CategoryId == parentcategoryid)
                                                        /*.Select(c => new Category()
                                                        {
                                                            CategoryId = c.CategoryId,
                                                            CategoryName = c.CategoryName,
                                                            CategoryOrder = c.CategoryOrder,
                                                            Deleted = c.Deleted,
                                                            SubCategories = databasecontext.Categories.Where(s => s.Category_ParentID == c.CategoryId).ToList()
                                                        })*/
                                                        .Include("SubCategories")
                                                        //.Include("Passwords")
                                                        //.Include(c => c.Passwords.Select(p => p.Creator))
                                                        //.ToList()
                                                        /*
                                                        .Select(c => new Category()
                                                        {

                                                            SubCategories = c.SubCategories
                                                                                .Where(sub => !sub.Deleted)
                                                                                .OrderBy(sub => sub.CategoryOrder)
                                                                                .ToList(),                          //make sure only undeleted subcategories are returned

                                                            Passwords = c.Passwords
                                                                                .Where(pass => !pass.Deleted
                                                                                //&& (
                                                                                //    (UserPasswordList.Any(up => up.PasswordId == pass.PasswordId && up.Id == UserId))
                                                                                //    || (userIsAdmin && ApplicationSettings.Default.AdminsHaveAccessToAllPasswords)
                                                                                //    || pass.Creator_Id == UserId
                                                                                //    )
                                                                                    )   //make sure only undeleted passwords - that the current user has acccess to - are returned
                                                                                .OrderBy(pass => pass.PasswordOrder)
                                                                                .ToList(),

                                                            CategoryId = c.CategoryId,
                                                            CategoryName = c.CategoryName,
                                                            Category_ParentID = c.Category_ParentID,
                                                            CategoryOrder = c.CategoryOrder,
                                                            Parent_Category = c.Parent_Category,
                                                            Deleted = c.Deleted
                                                        })*/
                                                        .Single(c => c.CategoryId == parentcategoryid);

            return CategoryItem;

        }
    }
}