using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Video_Application.Models;

namespace Video_Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VideosController : Controller
    {
        private readonly ILogger<VideosController> _logger;

        public VideosController(ILogger<VideosController> logger)
        {
            _logger = logger;
        }

        // Get single video with id 
        [HttpGet("{id}")]
        public IActionResult GetVideo() {
        
        }
        // Get all viedos
        [HttpGet]
        public IActionResult GetVideos()
        {

        }

        // Post video
        [HttpPost]
        public IActionResult CreateVideo()
        {

        }
    

        public IActionResult Index()
        {
            return View();
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