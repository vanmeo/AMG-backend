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
    
    public class DmThongbaoController : ControllerBase
    {

        private readonly IDmThongbaoRepository _DmThongbaoRepository;

        public DmThongbaoController(IDmThongbaoRepository DmThongbaoRepository)
        {
            _DmThongbaoRepository = DmThongbaoRepository;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_DmThongbaoRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //[HttpPost("action")]
        //public IActionResult SendSMS(string IdKenh, string sms, string sdtnhan)
        //{
        //    try
        //    {
        //        var Tb = _DmThongbaoRepository.Add(Thongbao);
        //        if (Tb != null)
        //            return Ok(Tb);
        //        else
        //            return StatusCode(StatusCodes.Status403Forbidden);

        //    }
        //    catch
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}
        //[HttpPost("action")]
        //public IActionResult SendSMS_files(string IdKenh, string sms, string sdtnhan, List<IFormFile> Files)
        //{
        //    try
        //    {
        //        var Tb = _DmThongbaoRepository.Add(Thongbao);
        //        if (Tb != null)
        //            return Ok(Tb);
        //        else
        //            return StatusCode(StatusCodes.Status403Forbidden);

        //    }
        //    catch
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}
        [HttpPost]
        public IActionResult Add(DmThongbaoVM Thongbao)
        {
            try
            {
                var Tb = _DmThongbaoRepository.Add(Thongbao);
                if (Tb != null)
                    return Ok(Tb);
                else
                    return StatusCode(StatusCodes.Status403Forbidden);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}