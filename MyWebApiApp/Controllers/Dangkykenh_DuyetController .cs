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

namespace AMGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class Dangkykenh_DuyetController : ControllerBase
    {

        private readonly IDangkykenh_DuyetRepository _Dangkykenh_DuyetRepository;

        public Dangkykenh_DuyetController(IDangkykenh_DuyetRepository Dangkykenh_DuyetRepository)
        {
            _Dangkykenh_DuyetRepository = Dangkykenh_DuyetRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_Dangkykenh_DuyetRepository.GetAll());
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
                var data = _Dangkykenh_DuyetRepository.GetById(id);
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
        public IActionResult Update(string id, Dangkykenh_Duyet Dangkykenh_duyet, string tencanbosua)
        {
            if (id != Dangkykenh_duyet.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _Dangkykenh_DuyetRepository.Update(Dangkykenh_duyet,tencanbosua);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id,string tencanbosua)
        {
            try
            {
                _Dangkykenh_DuyetRepository.Delete(id,tencanbosua);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("Vaosokenh")]
        public IActionResult Vaosoquanlykenh(string idKenh, SoquanlykenhVM Soquanlykenh, string tencanbo)
        {
            try
            {
                return Ok(_Dangkykenh_DuyetRepository.Vaosoquanlykenh(idKenh, Soquanlykenh,tencanbo));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}