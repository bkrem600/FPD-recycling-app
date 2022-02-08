using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using UWS.Shared;

namespace Project.Pages
{
    public class CreateFPDModel : RelatedPageModel
    {
        private CompanyX db;

        public CreateFPDModel(CompanyX injectedContext)
        {
            db = injectedContext;
        }

        public IActionResult OnGet()
        {
            PopulateCategoryDropDownList(db);
            return Page();
        }

        [BindProperty]
        public FPD FPD { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyFPD = new FPD();
            if (await TryUpdateModelAsync<FPD>(
                 emptyFPD,
                 "fpd",   // Prefix for form value.
                 f => f.ID, f => f.CategoryID, f => f.Size, f => f.Make, f => f.ModelCode, f => f.Year,
                f => f.Origin, f => f.FrontCasingSorting, f => f.BackCasingSorting))
            {
                try
                {
                    db.FPDs.Add(emptyFPD);
                    await db.SaveChangesAsync();
                    return RedirectToPage("IndexFPDs");
                }
                catch (Exception ex)
                {
                    return RedirectToPage("Error");
                }
            }

            // Select Ids if TryUpdateModelAsync fails.
            PopulateCategoryDropDownList(db, emptyFPD.CategoryID);
            return Page();
        }
    }
}