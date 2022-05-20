using MicroServiceSix.DataAccess;
using MicroServiceSix.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceSix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskSixController : ControllerBase
    {
        private IFireStoreDataAccess _firestore;

        public TaskSixController(IFireStoreDataAccess firestore)
        {
            _firestore = firestore;
        }


        [HttpGet("getexchangerate/{basecur}/{symbols}")]
        public IActionResult getExchangeRate(string basecur,string symbols )
        {
            ExchangeRateModel exchangeRateModel =  _firestore.getExchangeRate(basecur,symbols);


            if(exchangeRateModel == null)
            {
                NotFound();
            }
            var json = JsonConvert.SerializeObject(exchangeRateModel);
            return Ok(json);
        }
    }
}
