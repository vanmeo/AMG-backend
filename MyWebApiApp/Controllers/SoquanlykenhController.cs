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
    public class SoquanlykenhController : ControllerBase
    {

        private readonly ISoquanlykenhRepository _SoquanlykenhRepository;

        public SoquanlykenhController(ISoquanlykenhRepository SoquankenhRepository)
        {
            _SoquanlykenhRepository = SoquankenhRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_SoquanlykenhRepository.GetAll());
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
        public IActionResult Update(string id, Soquanlykenh Sokenh)
        {
            if (id != Sokenh.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _SoquanlykenhRepository.Update(Sokenh);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _SoquanlykenhRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
       
       
        [HttpPost]
        public IActionResult Add(SoquanlykenhVM Soquanly)
        {
            try
            {
                return Ok(_SoquanlykenhRepository.Add(Soquanly));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("ChangeStatus")]

        public IActionResult ChangeStatus(string idso, int trangthai)
        {
            try
            {
                return Ok(_SoquanlykenhRepository.ThaydoiTrangthai(idso, trangthai));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}