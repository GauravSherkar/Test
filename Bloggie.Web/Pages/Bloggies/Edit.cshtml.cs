using Bloggie.Web.Data;
using Bloggie.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Bloggies
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext dbContext;
        [BindProperty]
        public EditBlogSpot EditBlogSpot { get; set; }
        public EditModel(BloggieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var employee = dbContext.BlogPosts.Find(id);
            if (employee != null)
            {
                EditBlogSpot = new EditBlogSpot
                {
                    Id = employee.Id,
                    Heading = employee.Heading,
                    PageTitle = employee.PageTitle,
                    Content = employee.Content,
                    ShortDescription = employee.ShortDescription,
                    FeaturedImageUrl = employee.FeaturedImageUrl,
                    UrlHandle = employee.UrlHandle,
                    PublishedDate = employee.PublishedDate,
                    Author = employee.Author,
                    Visible = employee.Visible,
                };
            }
        }
        public void OnpostUpdate()
        {
            if (EditBlogSpot != null)
            {
                var existingEmployee = dbContext.BlogPosts.Find(EditBlogSpot.Id);
                if (existingEmployee != null)
                {
                  
                    existingEmployee.Heading = EditBlogSpot.Heading;
                    existingEmployee.PageTitle = EditBlogSpot.PageTitle;
                    existingEmployee.Content = EditBlogSpot.Content;
                    existingEmployee.ShortDescription = EditBlogSpot.ShortDescription;
                    existingEmployee.FeaturedImageUrl = EditBlogSpot.FeaturedImageUrl;
                    existingEmployee.UrlHandle = EditBlogSpot.UrlHandle;
                    existingEmployee.PublishedDate = EditBlogSpot.PublishedDate;
                    existingEmployee.Author = EditBlogSpot.Author;
                    existingEmployee.Visible = EditBlogSpot.Visible;

                  
                    dbContext.SaveChanges();
                    ViewData["Message"] = "Employee Update Succeessfully";

                }

            }
        }
        public IActionResult OnPostDelete()
        {
            var existingEmployee = dbContext.BlogPosts.Find(EditBlogSpot.Id);
            if (existingEmployee != null)
            {
                dbContext.BlogPosts.Remove(existingEmployee);
                dbContext.SaveChanges();
                return RedirectToPage("/Bloggies/List");
            }
            return Page();
        }
    }
}
