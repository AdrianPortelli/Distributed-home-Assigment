using MicroServiceTask2.DataAccess;
using MicroServiceTask2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasktwoController : ControllerBase
    {
        private IFireStoreDataAccess _firestore;

        public TasktwoController(IFireStoreDataAccess firestore)
        {
            _firestore = firestore;
        }

        [HttpGet("createfundaccount/{email}/{BankAccoutNo}/{Payee}/{BankCode}/{IBAN}/{Country}/{CurrencyCode}/{OpeningBalance}")]
        public IActionResult CreateFundAccount(string email,string BankAccoutNo, string Payee,string BankCode,string IBAN,string Country,string CurrencyCode,string OpeningBalance)
        {
            FundAccount fundAccount = new FundAccount();
            User user = new User();

            user.Email = email;

            fundAccount.BankAccoutNo = BankAccoutNo;
            fundAccount.Payee = Payee;
            fundAccount.BankCode = BankCode;
            fundAccount.IBAN = IBAN;
            fundAccount.Country = Country;
            fundAccount.CurrencyCode = CurrencyCode;
            fundAccount.OpeningBalance = OpeningBalance;

            _firestore.AddFundAccount(user, fundAccount);

            return Ok();
        }
    }
}
