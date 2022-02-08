using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using UWS.Shared;

namespace Project.Pages
{
    public class UpdateFPDModel : RelatedPageModel
    {
        private CompanyX db;

        public UpdateFPDModel(CompanyX injectedContext)
        {
            db = injectedContext;
        }

        [BindProperty]
        public FPD FPD { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            PopulateCategoryDropDownList(db);

            if (id == null)
            {
                return NotFound();
            }
            FPD = await db.FPDs.FindAsync(id);
            if (FPD == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var fpdToUpdate = await db.FPDs.FindAsync(id);
            if (fpdToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<FPD>(
                fpdToUpdate,
                "fpd",
                f => f.CategoryID, f => f.Size, f => f.Make, f => f.ModelCode, f => f.Year,
                f => f.Origin, f => f.FrontCasingSorting, f => f.BackCasingSorting))
            {
                try
                {
                    await db.SaveChangesAsync();
                    return RedirectToPage("IndexFPDs");
                }
                catch (Exception ex)
                {
                    return RedirectToPage("Error");
                }
            }
            // Select Ids if TryUpdateModelAsync fails.
            PopulateCategoryDropDownList(db, fpdToUpdate.CategoryID);

            return Page();
        }
    }
}

