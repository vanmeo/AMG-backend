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
    [Authorize]
    public class DmChucvuController : ControllerBase
    {
        private readonly IDmChucvuRepository _DmChucvuRepository;

        public DmChucvuController(IDmChucvuRepository DmChucvuRepository)
        {
            _DmChucvuRepository = DmChucvuRepository;
        }
        [HttpGet]
        //[Authorize(Roles = "CHUCVU_VIEW")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_DmChucvuRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "CHUCVU_VIEW")]
        public IActionResult GetById(string id)
        {
            try
            {
                var data = _DmChucvuRepository.GetById(id);
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
        //[Authorize(Roles = "CHUCVU_EDIT")]
        public IActionResult Update(string id, DmChucvu DmChucvu)
        {
            if (id != DmChucvu.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _DmChucvuRepository.Update(DmChucvu);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "CHUCVU_DELETE")]
        public IActionResult Delete(string id)
        {
            try
            {
                _DmChucvuRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "CHUCVU_ADD")]
        public IActionResult Add(DmChucvuVM DmChucvu)
        {
            try
            {
                return Ok(_DmChucvuRepository.Add(DmChucvu));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
