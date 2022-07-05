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
    public class DmUngdungController : ControllerBase
    {

        private readonly IDmUngdungRepository _DmUngdungRepository;

        public DmUngdungController(IDmUngdungRepository DmUngdungRepository)
        {
            _DmUngdungRepository = DmUngdungRepository;
        }
        [HttpGet]
        //[Authorize(Roles = "CAPBAC_VIEW")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_DmUngdungRepository.GetAll());
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
                var data = _DmUngdungRepository.GetById(id);
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
        public IActionResult Update(string id, DmUngdung DmUngdung)
        {
            if (id != DmUngdung.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _DmUngdungRepository.Update(DmUngdung);
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
                _DmUngdungRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "CAPBAC_ADD")]
        public IActionResult Add(DmUngdungVM DmUngdung)
        {
            try
            {
                return Ok(_DmUngdungRepository.Add(DmUngdung));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}