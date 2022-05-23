using DigitalWalletWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalWalletWebApp.API;

namespace DigitalWalletWebApp.Controllers
{
    public class TransferAndDepositController : Controller
    {
        private readonly MicroServiceThreeAPI microServiceThreeApi = MicroServiceThreeAPI.microserviceThreeAPI;

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult DepositFunds()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult DepositFunds(DepositFundsModel depositFunds)
        {
            string check = microServiceThreeApi.depositFunds("http://localhost:8082", User.Claims.ElementAt(4).Value, depositFunds.BackAccountNo, depositFunds.Funds);

            return RedirectToAction("listFundAccounts","FundAccount");
        }

        [Authorize]
        [HttpGet]
        public IActionResult TransferToSameOwnerAccounts()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult TransferToSameOwnerAccounts(SameOwnerTransferModel  sameOwnertransfer)
        {

            string check = microServiceThreeApi.sameOwnerFundsTransfer("http://localhost:8082", User.Claims.ElementAt(4).Value,sameOwnertransfer.DepositAccountNo,sameOwnertransfer.WithrdrawBacnkAccountNo,sameOwnertransfer.Funds);
            return RedirectToAction("listFundAccounts", "FundAccount");
        }


        [Authorize]
        [HttpGet]
        public IActionResult TransferToDifferentOwnerAccounts()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult TransferToDifferentOwnerAccounts(TransferToDifferentOwner transferToDifferentOwner)
        {
            string check = microServiceThreeApi.differntOwnerFundTransfer("http://localhost:8082", transferToDifferentOwner.IBAN, transferToDifferentOwner.DepositEmail,  User.Claims.ElementAt(4).Value, transferToDifferentOwner.WithdrawBackAccountNo,transferToDifferentOwner.Funds);
            return RedirectToAction("listFundAccounts", "FundAccount");
        }


    }
}
