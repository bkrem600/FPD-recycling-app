using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

using System.Linq;
using UWS.Shared;

namespace Project.Pages
{
    public class FPDsModel : PageModel
    {
        private CompanyX db;
        public FPDsModel(CompanyX injectedContext)
        {
            db = injectedContext;
        }

        public IList<FPD> FPDs { get; set; }

        public string IdSort { get; set; }
        public string CategorySort { get; set; }
        public string SizeSort { get; set; }
        public string MakeSort { get; set; }
        public string ModelCodeSort { get; set; }
        public string YearSort { get; set; }
        public string OriginSort { get; set; }
        public string FrontCasingSortingSort { get; set; }
        public string BackCasingSortingSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            IdSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            CategorySort = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            SizeSort = String.IsNullOrEmpty(sortOrder) ? "size_desc" : "";
            MakeSort = String.IsNullOrEmpty(sortOrder) ? "make_desc" : "";
            ModelCodeSort = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            YearSort = String.IsNullOrEmpty(sortOrder) ? "year_desc" : "";
            OriginSort = String.IsNullOrEmpty(sortOrder) ? "origin_desc" : "";
            FrontCasingSortingSort = String.IsNullOrEmpty(sortOrder) ? "front_desc" : "";
            BackCasingSortingSort = String.IsNullOrEmpty(sortOrder) ? "back_desc" : "";

            CurrentFilter = searchString;

            IQueryable<FPD> fpdsIQ = from f in db.FPDs
                                     select f;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                fpdsIQ = fpdsIQ.Where(f => f.Category.CategoryName.ToUpper().Contains(searchString.ToUpper())
                || f.Make.ToUpper().Contains(searchString.ToUpper())
                || f.ModelCode.ToUpper().Contains(searchString.ToUpper())
                || f.Origin.ToUpper().Contains(searchString.ToUpper())
                || f.FrontCasingSorting.ToUpper().Contains(searchString.ToUpper())
                || f.BackCasingSorting.ToUpper().Contains(searchString.ToUpper()));   
            }

            switch (sortOrder) 
            {
                case "id_desc":
                fpdsIQ = fpdsIQ.OrderByDescending(f => f.ID);
                break;
                case "category_desc":
                fpdsIQ = fpdsIQ.OrderByDescending(f => f.Category.CategoryName);
                break;
                case "size_desc":
                fpdsIQ = fpdsIQ.OrderByDescending(f => f.Size);
                break;
                case "make_desc":
                fpdsIQ = fpdsIQ.OrderByDescending(f => f.Make);
                break;
                case "model_desc":
                fpdsIQ = fpdsIQ.OrderByDescending(f => f.ModelCode);
                break;
                case "year_desc":
                fpdsIQ = fpdsIQ.OrderByDescending(f => f.Year);
                break;
                case "origin_desc":
                fpdsIQ = fpdsIQ.OrderByDescending(f => f.Origin);
                break;
                case "front_desc":
                fpdsIQ = fpdsIQ.OrderByDescending(f => f.FrontCasingSorting);
                break;
                case "back_desc":
                fpdsIQ = fpdsIQ.OrderByDescending(f => f.BackCasingSorting);
                break;
            }

            FPDs = await fpdsIQ
            .Include(f => f.Category)
            .AsNoTracking()
            .ToListAsync();
        }
    }
}