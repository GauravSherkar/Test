using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Bloggies
{
    public class AddModel : PageModel
    {
        private readonly BloggieDbContext dbContext;
        public AddModel(BloggieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public AddBlogSpot AddBlogSpotRequest { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var BlogSpotDomainModel = new BlogPost
            {
                Heading = AddBlogSpotRequest.Heading,
                PageTitle = AddBlogSpotRequest.PageTitle,
                Content = AddBlogSpotRequest.Content,
                ShortDescription = AddBlogSpotRequest.ShortDescription,
                FeaturedImageUrl = AddBlogSpotRequest.FeaturedImageUrl,
                UrlHandle = AddBlogSpotRequest.UrlHandle,
                PublishedDate = AddBlogSpotRequest.PublishedDate,
                Author = AddBlogSpotRequest.Author,
                Visible = AddBlogSpotRequest.Visible,
            };
            dbContext.BlogPosts.Add(BlogSpotDomainModel);
            dbContext.SaveChanges();
            ViewData["Message"] = "Employee created successfully";
        }
    }
}
