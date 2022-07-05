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
    public class DmRoleController : ControllerBase
    {

        private readonly IDmRoleRepository _DmRoleRepository;

        public DmRoleController(IDmRoleRepository DmRoleRepository)
        {
            _DmRoleRepository = DmRoleRepository;
        }
        [HttpGet]
       
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_DmRoleRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(string id)
        {
            try
            {
                var data = _DmRoleRepository.GetById(id);
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
        [Authorize]
        public IActionResult Update(string id, DmRole DmNhomquyen)
        {
            if (id != DmNhomquyen.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _DmRoleRepository.Update(DmNhomquyen);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            try
            {
                _DmRoleRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize]

        public IActionResult Add(DmRoleVM DmNhomquyen)
        {
            try
            {
                return Ok(_DmRoleRepository.Add(DmNhomquyen));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}