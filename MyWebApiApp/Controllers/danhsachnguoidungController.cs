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
using Newtonsoft.Json;

namespace AMGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DanhsachnguoidungController : ControllerBase
    {

        private readonly IDanhsachnguoidungRepository _DanhsachnguoidungRepository;

        public DanhsachnguoidungController(IDanhsachnguoidungRepository DanhsachnguoidungRepository)
        {
            _DanhsachnguoidungRepository = DanhsachnguoidungRepository;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginParameters paginParameters)
        {
            try
            {
                var owners = _DanhsachnguoidungRepository.getAll(paginParameters);
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
        public IActionResult findAll([FromQuery] PaginParameters paginParameters, string searchString)
        {
            try
            {
                var owners = _DanhsachnguoidungRepository.findAll(paginParameters, searchString);
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

        [HttpGet("{id}")]
        //[Authorize(Roles = "CAPBAC_VIEW")]
        public IActionResult GetById(string id)
        {
            try
            {
                var data = _DanhsachnguoidungRepository.GetById(id);
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
        //[Authorize(Roles = "CAPBAC_EDIT")]
        public IActionResult Update(string id, Danhsachnguoidung danhsachnguoidung)
        {
            if (id != danhsachnguoidung.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _DanhsachnguoidungRepository.Update(danhsachnguoidung);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "CAPBAC_DELETE")]
        public IActionResult Delete(string id)
        {
            try
            {
                _DanhsachnguoidungRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
      
        public IActionResult Add(DanhsachnguoidungVM danhsachnguoidungvm)
        {
            try
            {
                return Ok(_DanhsachnguoidungRepository.Add(danhsachnguoidungvm));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}