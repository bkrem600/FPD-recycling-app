using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;

using UWS.Shared;

namespace Project.Pages
{
    public class DeleteFPDModel : PageModel
    {
        private CompanyX db;

        public DeleteFPDModel(CompanyX injectedContext)
        {
            db = injectedContext;
        }
        [BindProperty]
        public FPD FPD { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FPD = await db.FPDs
            .Include(f => f.Category)
            .FirstOrDefaultAsync(f => f.ID == id);


            if (FPD == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FPD fpd = await db.FPDs
                        .SingleAsync(f => f.ID == id);

            if (fpd == null)
            {
                return RedirectToPage("IndexFPDs");
            }

            db.FPDs.Remove(fpd);
            await db.SaveChangesAsync();
            return RedirectToPage("IndexFPDs");
        }
    }
}

