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
    public class DmAppController : ControllerBase
    {

        private readonly IDmAppRepository _DmAppRepository;

        public DmAppController(IDmAppRepository DmAppRepository)
        {
            _DmAppRepository = DmAppRepository;
        }
        [HttpGet]
        //[Authorize(Roles = "CAPBAC_VIEW")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_DmAppRepository.GetAll());
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
                var data = _DmAppRepository.GetById(id);
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
        public IActionResult Update(string id, DmApp DmApp)
        {
            if (id != DmApp.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _DmAppRepository.Update(DmApp);
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
                _DmAppRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "CAPBAC_ADD")]
        public IActionResult Add(DmAppVM DmApp)
        {
            try
            {
                return Ok(_DmAppRepository.Add(DmApp));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}