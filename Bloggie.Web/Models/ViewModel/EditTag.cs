namespace Bloggie.Web.Models.ViewModel
{
    public class EditTag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BlogPostId { get; set; }
    }
}
