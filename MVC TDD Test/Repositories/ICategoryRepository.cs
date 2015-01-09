using MVC_TDD_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TDD_Test.Repositories
{
    public interface ICategoryRepository
    {
        Category GetCategoryItem(int parentid);
    }
}
