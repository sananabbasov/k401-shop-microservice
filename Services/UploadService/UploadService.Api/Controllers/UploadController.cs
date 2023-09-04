using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UploadService.Api.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file was provided.");
                }

                // Ensure a unique filename
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // Path to save the uploaded file
                var uploadPath = Path.Combine("wwwroot/uploads", uniqueFileName);

                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok("/uploads/" + uniqueFileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("uploads")]
        public async Task<IActionResult> UploadsAsync([FromForm] IFormFileCollection files)
        {
            try
            {
                if (files == null || files.Count == 0)
                {
                    return BadRequest("No files were provided.");
                }
                List<string> photoUrls = new();
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Ensure a unique filename
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        photoUrls.Add("wwwroot/uploads/" + uniqueFileName);
                        // Path to save the uploaded file
                        var uploadPath = Path.Combine("wwwroot/uploads", uniqueFileName);

                        using (var stream = new FileStream(uploadPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
                return Ok(photoUrls);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}

