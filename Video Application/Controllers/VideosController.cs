using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Video_Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        // GET: api/<VideosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VideosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No files received from the upload.");
            }

            try
            {

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        if (file.Length > 209715200)
                        {
                            return BadRequest($"File {file.FileName} exceeds the 200MB size limit.");
                        }

                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
                return Ok(new { message = "Files uploaded successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // DELETE api/<VideosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
