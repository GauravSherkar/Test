using Bloggie.Web.Data;
using Bloggie.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Bloggies
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext dbContext;
        public List<Models.Domain.BlogPost> BlogPosts { get; set; }
        public ListModel(BloggieDbContext dbContext)
        {

            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            BlogPosts = dbContext.BlogPosts.ToList();
        }
     
    }
}
