using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loodos.Controllers.API
{
    [Route("api/[controller]/{statusCode}")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        
        public IActionResult ErrorStatus(int statusCode) 
        {
            if (statusCode == 444)
            {
                return StatusCode(statusCode,"444 Hatası");
            }
            return StatusCode(200);
        }
    }
}