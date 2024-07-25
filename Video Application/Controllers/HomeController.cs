using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using Video_Application.Models;


namespace Video_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpclient)
        {
            _logger = logger;
            _httpClient = httpclient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetUploadViewComponent()
        {
            return ViewComponent("Upload");
        }
        [HttpGet]
        public IActionResult GetCatalogueViewComponent()
        {
            return ViewComponent("Catalogue");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ModelState.AddModelError("", "No files selected.");
                return View();
            }

            try
            {
                using (var content = new MultipartFormDataContent())
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            // Check if the file is an MP4
                            if (!file.ContentType.Equals("video/mp4", StringComparison.OrdinalIgnoreCase))
                            {
                                ModelState.AddModelError("", $"File {file.FileName} is not an MP4.");
                                continue; 
                            }
                                
                            var streamContent = new StreamContent(file.OpenReadStream());
                            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                            content.Add(streamContent, "files", file.FileName);
                        }
                    }

                    if (content.Any())
                    {
                        using (var httpClient = new HttpClient())
                        {
                            var response = await httpClient.PostAsync("https://your-api-url/api/files/upload", content);
                            if (response.IsSuccessStatusCode)
                            {
                                TempData["SuccessMessage"] = "Files uploaded successfully.";
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ModelState.AddModelError("", $"Error uploading files. Status code: {response.StatusCode}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}