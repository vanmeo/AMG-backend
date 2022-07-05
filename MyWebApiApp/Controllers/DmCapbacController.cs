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
    public class DmCapbacController : ControllerBase
    {

        private readonly IDmCapbacRepository _DmCapbacRepository;

        public DmCapbacController(IDmCapbacRepository DmCapbacRepository)
        {
            _DmCapbacRepository = DmCapbacRepository;
        }
        [HttpGet]
        //[Authorize(Roles = "CAPBAC_VIEW")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_DmCapbacRepository.GetAll());
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
                var data = _DmCapbacRepository.GetById(id);
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
        public IActionResult Update(string id, DmCapbac DmCapbac)
        {
            if (id != DmCapbac.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _DmCapbacRepository.Update(DmCapbac);
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
                _DmCapbacRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "CAPBAC_ADD")]
        public IActionResult Add(DmCapbacVM DmCapbac)
        {
            try
            {
                return Ok(_DmCapbacRepository.Add(DmCapbac));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}