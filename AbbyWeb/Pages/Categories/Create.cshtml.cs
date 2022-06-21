using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
	public class CreateModel : PageModel
	{
		private readonly ApplicationDbContext _db;
		[BindProperty]
		public Category Category { get; set; }

		public CreateModel(ApplicationDbContext db)
		{
			_db = db;

		}

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost(Category category)
		{
			if (Category.Name == Category.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the Name.");
			}

			if (ModelState.IsValid)
			{


				await _db.Category.AddAsync(category);
				await _db.SaveChangesAsync();
				return RedirectToPage("Index");
			}

			return Page();
		}
	}
}
