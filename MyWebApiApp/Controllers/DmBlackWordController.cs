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
    public class DmBlackWordController : ControllerBase
    {
        private readonly IDmBlackWordRepository _DmBlackWordRepository;

        public DmBlackWordController(IDmBlackWordRepository DmBlackWordRepository)
        {
            _DmBlackWordRepository = DmBlackWordRepository;
        }
        [HttpGet]
        //[Authorize(Roles = "CHUCVU_VIEW")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_DmBlackWordRepository.GetAll());
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
                var data = _DmBlackWordRepository.GetById(id);
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
        public IActionResult Update(string id, DmBlackWord Blackword)
        {
            if (id != Blackword.Id.ToString())
            {
                return BadRequest();
            }
            try
            {
                _DmBlackWordRepository.Update(Blackword);
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
                _DmBlackWordRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "CHUCVU_ADD")]
        public IActionResult Add(DmBlackWordVM Blackword)
        {
            try
            {
                return Ok(_DmBlackWordRepository.Add(Blackword));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);//StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
