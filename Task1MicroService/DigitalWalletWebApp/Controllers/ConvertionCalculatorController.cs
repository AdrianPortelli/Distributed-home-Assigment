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
    public class ConvertionCalculatorController : Controller
    {

        private readonly MicroServiceFiveAPI microServiceFiveAPI = MicroServiceFiveAPI.microserviceFiveAPI;

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Index(ConvertionCalModel convertionCal)
        {
            convertionCal.Result  =  microServiceFiveAPI.currencyConversion("https://microservicefive-rlz3wkvhza-uc.a.run.app", convertionCal.BaseSymbol,convertionCal.SymbolToConvertTo,convertionCal.Amount);


            var json = JsonConvert.SerializeObject(convertionCal);
            return RedirectToAction("convertionResult", new
            {
                jsonString = json

            }); ;
         
        }

        [Authorize]
        [HttpGet]
        public IActionResult convertionResult(string jsonString)
        {

            ConvertionCalModel view = JsonConvert.DeserializeObject<ConvertionCalModel>(jsonString);
            return View(view);
        }
    }
}
