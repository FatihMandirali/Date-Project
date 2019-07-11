using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.DateService;
using Application.DateService.Request;
using Application.DateService.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loodos.Controllers.API
{
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly IDateAppService _dateAppService;

        public DateController(IDateAppService dateAppService)
        {
            _dateAppService = dateAppService;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("api/{startDate}/{endDate}")]
        public IActionResult GetDateCreate(string startDate, string endDate)
        {

            DateTime _startDate, _endDate;
            if (DateTime.TryParse(startDate, out _startDate) && DateTime.TryParse(endDate, out _endDate))
            {
                DateRequest dateRequest = new DateRequest();
                dateRequest.startDate = _startDate;
                dateRequest.endDate = _endDate;
                var baseResponse = _dateAppService.DateCreate(dateRequest);
                return Ok(baseResponse);
            }
            else
            {
                BaseResponse baseResponse = new BaseResponse();
                baseResponse.isOkey = false;
                baseResponse.message = "Girdiğiniz Değerler Tarih Değildir";
                return Ok(baseResponse);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("api/[controller]/[action]")]
        public IActionResult GetLogList()
        {
            var logResponses = _dateAppService.LogList();
            return Ok(logResponses);
        }
    }
}