using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Uploadfile : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Uploadfile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("[action]")]
        public IActionResult uploadfiles(IFormFile file)
        {
            try
            {
                string filepath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadFiles", file.FileName);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
