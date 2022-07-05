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
    public class ThongsohethongController : ControllerBase
    {
        private readonly IThongsohethongRepository _ThongsohethongRepository;

        public ThongsohethongController(IThongsohethongRepository ThongsohethongRepository)
        {
            _ThongsohethongRepository = ThongsohethongRepository;
        }

        [HttpGet]
        //[Authorize(Roles = "CHUCVU_VIEW")]
        public IActionResult GetThongsohethong()
        {
            try
            {
                var data = _ThongsohethongRepository.GetThongsohethong();
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

        [HttpPut]
        //[Authorize(Roles  "CHUCVU_EDIT")]
        public IActionResult Update(ThongsoHethong thongsoHT)
        {

            try
            {
                _ThongsohethongRepository.Update(thongsoHT);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
