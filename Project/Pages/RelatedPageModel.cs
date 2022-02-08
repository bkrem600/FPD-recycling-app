using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using UWS.Shared;

namespace Project.Pages
{
    public class RelatedPageModel : PageModel
    {
        public SelectList CategoryNameSL { get; set; }

        public void PopulateCategoryDropDownList(CompanyX db,
            object selectedCategory = null)
        {
            var categoriesQuery = from c in db.Categories
                                  orderby c.CategoryName // Sort by category name.
                                  select c;

            CategoryNameSL = new SelectList(categoriesQuery.AsNoTracking(),
                        "CategoryID", "CategoryName", selectedCategory);
        }
    }
}