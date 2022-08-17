using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;

namespace AMGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SoquanlykenhController : ControllerBase
    {

        private readonly ISoquanlykenhRepository _SoquanlykenhRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SoquanlykenhController(ISoquanlykenhRepository SoquankenhRepository, IWebHostEnvironment webHostEnvironment)
        {
            _SoquanlykenhRepository = SoquankenhRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginParameters paginParameters)
        {
            try
            {
                var owners = _SoquanlykenhRepository.getAll(paginParameters);
                var metadata = new
                {
                    owners.TotalCount,
                    owners.PageSize,
                    owners.CurrentPage,
                    owners.TotalPages,
                    owners.HasNext,
                    owners.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                // _logger.LogInfo($"Returned {owners.TotalCount} owners from database.");
                return Ok(owners);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("search")]
        public IActionResult findAll([FromQuery] PaginParameters paginParameters, string searchString, string IdDonvi, DateTime from, DateTime to, int Trangthaikenh)
        {
            try
            {
                var owners = _SoquanlykenhRepository.findAll(paginParameters, searchString, IdDonvi, from, to, Trangthaikenh);
                var metadata = new
                {
                    owners.TotalCount,
                    owners.PageSize,
                    owners.CurrentPage,
                    owners.TotalPages,
                    owners.HasNext,
                    owners.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
               
                return Ok(owners);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var data = _SoquanlykenhRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Soquanlykenh Sokenh,string tencanbosua)
        {
            if (id != Sokenh.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _SoquanlykenhRepository.Update(Sokenh,tencanbosua);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id,string tencanboxoa)
        {
            try
            {
                _SoquanlykenhRepository.Delete(id,tencanboxoa);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
       
       
        [HttpPost]
        public IActionResult Add(SoquanlykenhVM Soquanly,string tencanbotao)
        {
            try
            {
                return Ok(_SoquanlykenhRepository.Add(Soquanly, tencanbotao));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("ChangeStatus")]

        public IActionResult ChangeStatus(string idso, int trangthai,string tencanbo)
        {
            try
            {
                return Ok(_SoquanlykenhRepository.ThaydoiTrangthai(idso, trangthai,tencanbo));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("[action]")]
        public IActionResult UploadDsnguoidung(IFormFile file, string idsokenh, string idcanbotao)
        {
            try
            {
                string filepath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadFiles", file.FileName);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                _SoquanlykenhRepository.Themdanhsachnguoidung(idsokenh, idcanbotao, filepath);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}