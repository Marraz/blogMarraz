using blogMarraz.Models;
using blogMarraz.Models.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace blogMarraz.Controllers
{
    //Default controller
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDbContext _blogDbContext;

        public HomeController(ILogger<HomeController> logger, BlogDbContext blogDbContext)
        {
            _logger = logger;
            _blogDbContext = blogDbContext;
            
            if (_blogDbContext == null)
            {
                throw new ArgumentNullException("No database found");
            }
        }
        [Route("/")]
        public IActionResult Index()
        {
            //_blogDbContext.CreateExamplePosts();

            return View(_blogDbContext.Posts.ToList().FindAll(
                p => p.Public == true &&
                p.Created <= DateTime.UtcNow &&
                p.Deleted == false));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
