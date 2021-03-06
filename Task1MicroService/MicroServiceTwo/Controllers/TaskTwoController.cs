using MicroServiceTwo.DataAccess;
using MicroServiceTwo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTwo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskTwoController : ControllerBase
    {
        private IFireStoreDataAccess _firestore;

        public TaskTwoController(IFireStoreDataAccess firestore)
        {
            _firestore = firestore;
        }

        [HttpGet("createfundaccount/{email}/{BankAccoutNo}/{Payee}/{BankCode}/{IBAN}/{Country}/{CurrencyCode}/{OpeningBalance}")]
        public IActionResult CreateFundAccount(string email, string BankAccoutNo, string Payee, string BankCode, string IBAN, string Country, string CurrencyCode, int OpeningBalance)
        {
            FundAccount fundAccount = new FundAccount();
            User user = new User();

            user.Email = email;

            fundAccount.BankAccountNo = BankAccoutNo;
            fundAccount.Payee = Payee;
            fundAccount.BankCode = BankCode;
            fundAccount.IBAN = IBAN;
            fundAccount.Country = Country;
            fundAccount.CurrencyCode = CurrencyCode;
            fundAccount.OpeningBalance = OpeningBalance;
            fundAccount.Balance = OpeningBalance;
            fundAccount.Status = "not-disabled";

            _firestore.AddFundAccount(user, fundAccount);


            jsonStatus jsonStatus = new jsonStatus();
            jsonStatus.Status = "Successful";
            var json  = JsonConvert.SerializeObject(jsonStatus);
            return Ok(json);
           
        }



        [HttpGet("disablefundaccount/{email}/{BankAccoutNo}/")]
        public IActionResult DisableFundAccount(string email, string BankAccoutNo)
        {
             Task<bool> check =  _firestore.DisableFundAccount(email, BankAccoutNo);
           


            if(check.Result == true){
                jsonStatus jsonStatus = new jsonStatus();
                jsonStatus.Status = "Successful";
                var json  = JsonConvert.SerializeObject(jsonStatus);
                return Ok(json);
            }
            else
            {
                jsonStatus jsonStatus = new jsonStatus();
                jsonStatus.Status = "Unsuccessful";
                var json = JsonConvert.SerializeObject(jsonStatus);
                return NotFound(json);
            }
        }


        [HttpGet("listfundaccount/{email}/")]
        public IActionResult listFundaccount(string email)
        {
            Task<List <FundAccount>> fundAccounts = _firestore.GetFundAccounts(email);
            var json = JsonConvert.SerializeObject(fundAccounts.Result);


            if (fundAccounts.Result.Count == 0)
            {
                jsonStatus jsonStatus = new jsonStatus();
                jsonStatus.Status = "Unsuccessful";
                var json_listfund = JsonConvert.SerializeObject(jsonStatus);

                return NotFound(json_listfund);
            }
            else
            {
            
                return Ok(json);
            }
        }



        [HttpGet("searchFundAccount/{email}/{bankaccountno}")]
        public IActionResult searchFundAccount(string email,string bankaccountno)
        {
            Task<FundAccount> fundAccount = _firestore.GetFundAccount(email, bankaccountno);

            var json = JsonConvert.SerializeObject(fundAccount.Result);

            if (fundAccount.Result == null)
            {
                jsonStatus jsonStatus = new jsonStatus();
                jsonStatus.Status = "Unsuccessful";
                var json_listfund = JsonConvert.SerializeObject(jsonStatus);

                return NotFound(json_listfund);
            }
            else
            {
                return Ok(json);
            }
        }
    }
}
