using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using blogMarraz.Models.Repos;

namespace blogMarraz.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDbContext _blogDbContext;
        public PostController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        [Route("/post/{postTitle}")]
        public IActionResult Index([FromRoute] string postTitle)
        {
            return View(_blogDbContext.Posts.ToList().Find(
                 p => p.Title == postTitle.Replace("-", " ")));
        }
    }
}
