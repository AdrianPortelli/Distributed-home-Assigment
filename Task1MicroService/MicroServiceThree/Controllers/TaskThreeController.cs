using MicroServiceThree.DataAccess;
using MicroServiceThree.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                transaction.Email = email;
                transaction.AccountNo = bankaccountno;
                transaction.TranscationType = "Deposit";
                transaction.Funds = funds;
                _firestore.createTransactionLog(transaction);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("sameownerfundtransfer/{email}/{depositbankaccountno}/{withdrawbankaccountno}/{funds}")]
        public IActionResult SameOwnerFundTransfer(string email, string depositbankaccountno, string withdrawbankaccountno, double funds)
        {
            bool check = _firestore.TranferFundsToSameOwner(email, withdrawbankaccountno, depositbankaccountno, funds);

            if (check == true)
            {
                Transactions transaction = new Transactions();
                transaction.Email = email;
                transaction.AccountNo = withdrawbankaccountno;
                transaction.TranscationType = "Transfer_Same_Owner_Account";
                transaction.FundsTransferedSameOwnerAccountNo = depositbankaccountno;
                transaction.Funds = funds;

                Transactions transactionForAccountRecivingTransfer = new Transactions();
                transactionForAccountRecivingTransfer.Email = email;
                transactionForAccountRecivingTransfer.AccountNo = depositbankaccountno;
                transactionForAccountRecivingTransfer.TranscationType = "Recived_transfer_From_Same_Owner_Account";
                transactionForAccountRecivingTransfer.FundsTransferedSameOwnerAccountNo = withdrawbankaccountno;
                transactionForAccountRecivingTransfer.Funds = funds;

                //log for other fund account
                _firestore.createTransactionLog(transaction);
                _firestore.createTransactionLog(transactionForAccountRecivingTransfer);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }


        [HttpGet("differntownerfundtransfer/{IBAN}/depositemail/{withdrawemail}/{withdrawbankaccountno}/{funds}")]
        public IActionResult DifferntOwnerFundTransfer(string IBAN, string depositemail, string withdrawemail, string withdrawbankaccountno, double funds)
        {
            bool check = _firestore.TranferFundsToDifferntOwner(withdrawemail, depositemail, withdrawbankaccountno, IBAN, funds);

            if (check == true)
            {
                
                Transactions transaction = new Transactions();
                transaction.Email = withdrawemail;
                transaction.AccountNo = withdrawbankaccountno;
                transaction.TranscationType = "Transfer_Different_Owner";
                transaction.FundsTransferedtoIBAN = IBAN;
                transaction.Funds = funds;

                Transactions transactionForAccountRecivingTransfer = new Transactions();
                transactionForAccountRecivingTransfer.Email = depositemail;
                transactionForAccountRecivingTransfer.Funds = funds;
                transactionForAccountRecivingTransfer.TranscationType = "Recived_transfer_From_Third_Party_Account";
                //log for other fund account

                _firestore.createTransactionLog(transaction);
                _firestore.createTransactionLog(withdrawemail,withdrawbankaccountno, depositemail,IBAN, transactionForAccountRecivingTransfer);
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
