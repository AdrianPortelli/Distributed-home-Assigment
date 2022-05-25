using DigitalWalletWebApp.API;
using DigitalWalletWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.Controllers
{
    public class FundAccountController : Controller
    {

        private readonly MicroServiceTwoAPI microServiceTwoApi = MicroServiceTwoAPI.microSerivceTwo;

        public IActionResult Index()
        {
            return View();
        }




        [Authorize]
        [HttpGet]
        public IActionResult createFundAccount()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult createFundAccount(FundAccount fundaccount)
        {
            string check = microServiceTwoApi.createAccount("https://microservicetwo-rlz3wkvhza-uc.a.run.app", User.Claims.ElementAt(4).Value, fundaccount.BankAccountNo, fundaccount.Payee, fundaccount.BankCode, fundaccount.IBAN, fundaccount.Country, fundaccount.CurrencyCode, fundaccount.OpeningBalance);


            if (check == null)
            {


                return RedirectToAction("Index", "Home");
            }


            return RedirectToAction("Index", "Home");
        }


        public void disableAccount(string accountno)
        {
            microServiceTwoApi.disableFundAccount("https://microservicetwo-rlz3wkvhza-uc.a.run.app", User.Claims.ElementAt(4).Value, accountno);
        }

        [Authorize]
        [HttpGet]
        public IActionResult listFundAccounts()
        {

            var list = microServiceTwoApi.getFundList("https://microservicetwo-rlz3wkvhza-uc.a.run.app", User.Claims.ElementAt(4).Value);
            return View(list);
        }

        [Authorize]
        [HttpGet]
        public IActionResult displayFundAccount(string jsonString)
        {
            FundAccount fundAccount = JsonConvert.DeserializeObject<FundAccount>(jsonString);
            return View(fundAccount);
        }

        [Authorize]
        [HttpGet]
        public IActionResult searchFundAccount()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult searchFundAccount(FundAccount account)
        {
            FundAccount fundaccount = microServiceTwoApi.SearchAccount("https://microservicetwo-rlz3wkvhza-uc.a.run.app", User.Claims.ElementAt(4).Value, account.BankAccountNo);

            if(fundaccount == null)
            {
                return RedirectToAction("listFundAccounts");
            }
            string json = JsonConvert.SerializeObject(fundaccount);
            return RedirectToAction("displayFundAccount", new
            {
                jsonString = json
            });
        }
    }
}
