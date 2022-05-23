using MicroServiceThree.DataAccess;
using MicroServiceThree.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceThree.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskThreeController : ControllerBase
    {
        private IFireStoreDataAccess _firestore;

        public TaskThreeController(IFireStoreDataAccess firestore)
        {
            _firestore = firestore;
        }


        [HttpGet("depositfunds/{email}/{bankaccountno}/{funds}")]
        public IActionResult DepositFunds(string email,string bankaccountno,double funds)
        {
          bool check =  _firestore.depositfunds(email,bankaccountno,funds).Result;

            if (check == true)
            {
                Transactions transaction = new Transactions();
                transaction.ID = Guid.NewGuid().ToString();
                transaction.Email = email;
                transaction.AccountNo = bankaccountno;
                transaction.TranscationType = "Deposit";
                transaction.Funds = funds;
                transaction.TranscationDateTime =  DateTime.UtcNow;
                _firestore.createTransactionLog(transaction);

                jsonStatus jsonStatus = new jsonStatus();
                jsonStatus.Status = "Successful";
                var json = JsonConvert.SerializeObject(jsonStatus);
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

        [HttpGet("sameownerfundtransfer/{email}/{depositbankaccountno}/{withdrawbankaccountno}/{funds}")]
        public IActionResult SameOwnerFundTransfer(string email, string depositbankaccountno, string withdrawbankaccountno, double funds)
        {
            bool check = _firestore.TranferFundsToSameOwner(email, withdrawbankaccountno, depositbankaccountno, funds);

            if (check == true)
            {
                Transactions transaction = new Transactions();
                transaction.ID = Guid.NewGuid().ToString();
                transaction.Email = email;
                transaction.AccountNo = withdrawbankaccountno;
                transaction.TranscationType = "Transfer_Same_Owner_Account";
                transaction.FundsTransferedSameOwnerAccountNo = depositbankaccountno;
                transaction.Funds = funds;
                transaction.TranscationDateTime = DateTime.UtcNow;

                Transactions transactionForAccountRecivingTransfer = new Transactions();
                transactionForAccountRecivingTransfer.ID = Guid.NewGuid().ToString();
                transactionForAccountRecivingTransfer.Email = email;
                transactionForAccountRecivingTransfer.AccountNo = depositbankaccountno;
                transactionForAccountRecivingTransfer.TranscationType = "Recived_transfer_From_Same_Owner_Account";
                transactionForAccountRecivingTransfer.FundsTransferedSameOwnerAccountNo = withdrawbankaccountno;
                transactionForAccountRecivingTransfer.Funds = funds;
                transactionForAccountRecivingTransfer.TranscationDateTime = DateTime.UtcNow;

                //log for other fund account
                _firestore.createTransactionLog(transaction);
                _firestore.createTransactionLog(transactionForAccountRecivingTransfer);

                jsonStatus jsonStatus = new jsonStatus();
                jsonStatus.Status = "Successful";
                var json = JsonConvert.SerializeObject(jsonStatus);
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


        [HttpGet("differntownerfundtransfer/{IBAN}/{depositemail}/{withdrawemail}/{withdrawbankaccountno}/{funds}")]
        public IActionResult DifferntOwnerFundTransfer(string IBAN, string depositemail, string withdrawemail, string withdrawbankaccountno, double funds)
        {
            bool check = _firestore.TranferFundsToDifferntOwner(withdrawemail, depositemail, withdrawbankaccountno, IBAN, funds);

            if (check == true)
            {
                
                Transactions transaction = new Transactions();
                transaction.ID = Guid.NewGuid().ToString();
                transaction.Email = withdrawemail;
                transaction.AccountNo = withdrawbankaccountno;
                transaction.TranscationType = "Transfer_Different_Owner";
                transaction.FundsTransferedtoIBAN = IBAN;
                transaction.Funds = funds;
                transaction.TranscationDateTime = DateTime.UtcNow;

                Transactions transactionForAccountRecivingTransfer = new Transactions();
                transactionForAccountRecivingTransfer.ID = Guid.NewGuid().ToString(); 
                transactionForAccountRecivingTransfer.Email = depositemail;
                transactionForAccountRecivingTransfer.Funds = funds;
                transactionForAccountRecivingTransfer.TranscationType = "Recived_transfer_From_Third_Party_Account";
                transactionForAccountRecivingTransfer.TranscationDateTime = DateTime.UtcNow;
                //log for other fund account

                _firestore.createTransactionLog(transaction);
                _firestore.createTransactionLog(withdrawemail,withdrawbankaccountno,IBAN, transactionForAccountRecivingTransfer);

                jsonStatus jsonStatus = new jsonStatus();
                jsonStatus.Status = "Successful";
                var json = JsonConvert.SerializeObject(jsonStatus);
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
    }
}
