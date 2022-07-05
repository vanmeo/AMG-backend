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
    public class DangkykenhController : ControllerBase
    {

        private readonly IDangkykenhRepository _DangkykenhRepository;

        public DangkykenhController(IDangkykenhRepository DangkykenhRepository)
        {
            _DangkykenhRepository = DangkykenhRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_DangkykenhRepository.GetAll());
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
                var data = _DangkykenhRepository.GetById(id);
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
        public IActionResult Update(string id, Dangkykenh Dangkykenh)
        {
            if (id != Dangkykenh.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _DangkykenhRepository.Update(Dangkykenh);
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
                _DangkykenhRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
       
        [HttpPut("ChangeStatus")]

        public IActionResult ChangeStatus(string idkenh, int trangthai)
        {
            try
            {
                return Ok(_DangkykenhRepository.ThaydoiTrangthai(idkenh, trangthai));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add(DangkykenhVM dangkykenh)
        {
            try
            {
                return Ok(_DangkykenhRepository.Add(dangkykenh));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("DuyetKenh")]
        public IActionResult DuyetKenh(string idKenh,Dangkykenh_DuyetVM dangkykenh)
        {
            try
            {
                return Ok(_DangkykenhRepository.DuyetKenh(idKenh,dangkykenh));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}