using MicroServiceSeven.API;
using MicroServiceSeven.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceSeven.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskSevenController : ControllerBase
    {

        private readonly twitterAPI twitterApi = twitterAPI.twitterapi;
        [HttpGet("getalltweets")]
        public IActionResult getalltweets()
        {
            List<twitterModel> news = twitterApi.getRecentNews();
            var json = JsonConvert.SerializeObject(news);

            return Ok(json);
        }
    }
}

   
