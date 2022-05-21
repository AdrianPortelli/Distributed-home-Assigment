using MicroServiceFive.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceFive.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskFiveCalController : ControllerBase
    {

  

        [HttpGet("currencyConversion/{baseSymbol}/{symbol}/{amount}")]
        public IActionResult currencyConversion(string baseSymbol,string symbol,double amount)
        {
            ConvertionCal convertionCal = new ConvertionCal();
            double results = convertionCal.Convert(amount, baseSymbol, symbol);
            var json = JsonConvert.SerializeObject(results);
            return Ok(json);
          
        }
    }
}
