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
    public class DmDonviController : ControllerBase
    {


        private readonly IDmDonviRepository _DmDonviRepository;

        public DmDonviController(IDmDonviRepository DmDonviRepository)
        {
            _DmDonviRepository = DmDonviRepository;
        }
        [HttpGet]
        //[Authorize(Roles = "DONVI_VIEW")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_DmDonviRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "DONVI_VIEW")]
        public IActionResult GetById(string id)
        {
            try
            {
                var data = _DmDonviRepository.GetById(id);
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
        //[Authorize(Roles = "DONVI_EDIT")]
        public IActionResult Update(string id, DmDonvi DmDonvi)
        {
            if (id != DmDonvi.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _DmDonviRepository.Update(DmDonvi);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "DONVI_DELETE")]
        public IActionResult Delete(string id)
        {
            try
            {
                _DmDonviRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "DONVI_ADD")]
        public IActionResult Add(DmDonviVM DmDonvi)
        {
            try
            {
                return Ok(_DmDonviRepository.Add(DmDonvi));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}