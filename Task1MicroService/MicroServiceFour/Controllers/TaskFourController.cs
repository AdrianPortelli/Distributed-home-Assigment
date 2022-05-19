using MicroServiceFour.DataAccess;
using MicroServiceFour.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceFour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskFourController : ControllerBase
    {
        private IFireStoreDataAccess _firestore;

        public TaskFourController(IFireStoreDataAccess firestore)
        {
            _firestore = firestore;
        }

        [HttpGet("getalltranscations/{email}")]
        public IActionResult getalltranscations(string email)
        {

            List<Transactions> transactions= _firestore.getAllTranscations(email).Result;
            var json = JsonConvert.SerializeObject(transactions);
            return Ok(json);
        }



        [HttpGet("gettranscationsbyaccoutno/{email}/{accountno}")]
        public IActionResult getTranscationsByAccoutno(string email, string accountno)
        {

            List<Transactions> transactions = _firestore.getTranscationsForSpecificAccount(email, accountno).Result;
            var json = JsonConvert.SerializeObject(transactions);
            return Ok(json);
        }


        [HttpGet("gettranscationsbyaccoutno/{email}/{start}/{end}")]
        public IActionResult getTranscationsByRange(string email,string start,string end)
        {
            DateTime startDT = DateTime.Parse(start);
            DateTime endDT = DateTime.Parse(end);

            List<Transactions> transactions = _firestore.GetTransactionsByDateRange(email, startDT, startDT, endDT).Result;
            var json = JsonConvert.SerializeObject(transactions);
            return Ok(json);
        }
    }
}
