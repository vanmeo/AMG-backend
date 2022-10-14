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
using Microsoft.AspNetCore.Hosting;

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
        [HttpGet("SendSMS")]
        public IActionResult SendSMS(string sdtgui,string TenKenh, string tieude, string sms, string DSsdtnhan)
        {
            try
            {
                var Tb = _DmThongbaoRepository.sendsms(sdtgui,TenKenh,tieude,sms,DSsdtnhan);
                if (Tb)
                    return Ok();
                else
                    return StatusCode(StatusCodes.Status403Forbidden);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("Sendfiles")]
        public IActionResult Sendfiles(string sodienthoaigui,string TenKenh,string tieude, string sms, string DSsdtnhan, List<IFormFile> Files)
        {


            try
            {
                var Tb = _DmThongbaoRepository.sendsmsfile(sodienthoaigui,tieude,TenKenh,sms,DSsdtnhan,Files);
                if (Tb)
                    return Ok(Tb);
                else
                    return Content("Kích thước file lớn hơn kích thước cho phép");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
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