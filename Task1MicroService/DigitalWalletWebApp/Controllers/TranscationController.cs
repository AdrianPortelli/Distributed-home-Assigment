using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalWalletWebApp.API;
using DigitalWalletWebApp.Models;
using Newtonsoft.Json;

namespace DigitalWalletWebApp.Controllers
{
    public class TranscationController : Controller
    {

        private readonly MicroServiceFourAPI microServiceFourAPI = MicroServiceFourAPI.microserviceFourAPI;

        public IActionResult Index()
        {
            return View();
        }



        [Authorize]
        [HttpGet]
        public IActionResult AllTranscations()
        {
            var list = microServiceFourAPI.getAllTranscations("http://localhost:8083", User.Claims.ElementAt(4).Value);

            return View(list);
        }



        [Authorize]
        [HttpGet]
        public IActionResult filteredTransactionList(string jsonString)
        {

            var transactions = JsonConvert.DeserializeObject<List<Transactions>>(jsonString);

            return View(transactions);
        }


        [Authorize]
        [HttpGet]
        public IActionResult filterByAccountno()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult filterByAccountno(FundAccount fundAccount)
        {
            var list = microServiceFourAPI.getTranscationsByAccountno("http://localhost:8083", User.Claims.ElementAt(4).Value, fundAccount.BankAccountNo);


            if(list.Count == 0)
            {
                return RedirectToAction("AllTranscations");
            }

            var json = JsonConvert.SerializeObject(list);
            return RedirectToAction("filteredTransactionList", new
            {
                jsonString = json

            }); ;
        }

        [Authorize]
        [HttpGet]
        public IActionResult filterByDateRange()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult filterByDateRange(FundAccountWithDateRange fundAccountWithDateRange)
        {
            var list = microServiceFourAPI.getTranscationsByRange("http://localhost:8083",fundAccountWithDateRange.BankAccountNo,fundAccountWithDateRange.Start,fundAccountWithDateRange.End);
            
            if (list.Count == 0)
            {
                return RedirectToAction("AllTranscations");
            }

            var json = JsonConvert.SerializeObject(list);
            return RedirectToAction("filteredTransactionList", new
            {
                jsonString = json

            }); ;
        }

    }
}
