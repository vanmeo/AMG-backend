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
using System.Net.Mime;

namespace AMGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {

        private readonly IReportRepository _ReportRepository;

        public ReportController(IReportRepository ReportRepository)
        {
            _ReportRepository = ReportRepository;
        }
        [HttpGet("Ga_bc_tonghop/{reportType}")]
        public ActionResult BcTonghopkenh(string reportType)
        {
            var reportFileByteString = _ReportRepository.BaocaoTongHopSoKenh( reportType);
            return File(reportFileByteString, MediaTypeNames.Application.Octet, getReportName("InGa_bc_tonghop", reportType));
        }
        [HttpGet("Ga_bc_chitiet1kenh/{reportType}/{IdKenh}")]
        public ActionResult BcChitietkenh(string reportType, string IdKenh)
        {
            var reportFileByteString = _ReportRepository.BaocaoChitiet1Kenh(reportType, IdKenh);
            return File(reportFileByteString, MediaTypeNames.Application.Octet, getReportName("InGa_bc_chitiet1kenh", reportType));
        }


        private string getReportName(string reportName, string reportType)
        {
            var outputFileName = reportName + ".pdf";

            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    outputFileName = reportName + ".pdf";
                    break;
                case "XLS":
                    outputFileName = reportName + ".xls";
                    break;
                case "WORD":
                    outputFileName = reportName + ".doc";
                    break;
            }

            return outputFileName;
        }
    }
}