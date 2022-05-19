using Google.Cloud.Firestore;
using MicroServiceThree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceThree.DataAccess
{
    public class FireStoreDataAccess : IFireStoreDataAccess
    {
        private FirestoreDb db { get; set; }

        public FireStoreDataAccess(string project)
        {
            db = FirestoreDb.Create(project);
        }

        ConvertionCal convertionCal = new ConvertionCal();

        public async void createTransactionLog(Transactions transaction)
        {
            var document = await db.Collection("transactions").Document(transaction.Email).GetSnapshotAsync();
            if (document.Exists)
            {
                DocumentReference doc = db.Collection("transactions").Document(transaction.Email).Collection("fundaccounttransactions").Document(transaction.ID);
                await doc.SetAsync(transaction);

                return;
            }

            DocumentReference docRef = db.Collection("transactions").Document(transaction.Email).Collection("fundaccounttransactions").Document(transaction.ID);
            await docRef.SetAsync(transaction);

         
        }

        public  void createTransactionLog(string withdrawalEmail,string withdrawalAccountNo,string IBAN,Transactions transaction)
        {
            FundAccount fundAccount =  getFundAccountByIBAN(transaction.Email,IBAN).Result;
            FundAccount withdrawalFundAccount = getFundAccount(withdrawalEmail, withdrawalAccountNo).Result;

            transaction.FundsTransferedtoIBAN = withdrawalFundAccount.IBAN;
            transaction.AccountNo = fundAccount.BankAccountNo;


            createTransactionLog(transaction);
        }



        private async Task<double> getbalance(string email, string backaccountno)
        {
            DocumentReference doc = db.Collection("users").Document(email).Collection("fundaccounts").Document(backaccountno);
            DocumentSnapshot snapshot = await doc.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                FundAccount fundaccount = snapshot.ConvertTo<FundAccount>();
                return fundaccount.Balance;

            }
            else
            {
                return int.MinValue;

            }
        }

        private async Task<FundAccount> getFundAccountByIBAN(string email,string IBAN)
        {
            Query query = db.Collection("users").Document(email).Collection("fundaccounts").WhereEqualTo("IBAN", IBAN);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                FundAccount fundaccount = documentSnapshot.ConvertTo<FundAccount>();
                return fundaccount;
            }

            return null;
        }

        private async Task<FundAccount> getFundAccount(string email,string bankaccountno)
        {

            DocumentReference docfa = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
            DocumentSnapshot snapshot = await docfa.GetSnapshotAsync();
            return snapshot.ConvertTo<FundAccount>();
        }

        public bool TranferFundsToSameOwner(string email, string backAccountNoWithdraw, string backAccountNoDeposit, double fundstodeposit)
        {
            // requires exchange rate
            FundAccount withdrawAccount = withdraw(email, backAccountNoWithdraw, fundstodeposit).Result;

            if (withdrawAccount != null)
            {
               return TranferFundsFromAnotherAccount(email, backAccountNoDeposit,null, fundstodeposit, withdrawAccount.CurrencyCode).Result;
            }

            return false;
          
        }


        public  bool TranferFundsToDifferntOwner(string email, string emaildeposit,string backAccountNoWithdraw, string depositIBAN, double fundstodeposit)
        {
            

            FundAccount withdrawAccount = withdraw(email, backAccountNoWithdraw, fundstodeposit).Result;

            if (withdrawAccount != null)
            {
                return TranferFundsFromAnotherAccount(emaildeposit, null , depositIBAN, fundstodeposit, withdrawAccount.CurrencyCode).Result;
            }

            return false;



        }

        private async Task<bool> TranferFundsFromAnotherAccount(string email , string bankaccountno,string depositIBAN, double fundstodeposit, string currencyCode)
        {
            FundAccount fundaccount = null;
            if ( bankaccountno == null)
            {
               
              
                    fundaccount = getFundAccountByIBAN(email, depositIBAN).Result;
                    if (fundaccount == null)
                    {
                        return false;
                    }
              
            
            }
            else
            { 
                fundaccount = getFundAccount(email, bankaccountno).Result;
            }
           
            
            if (fundaccount.Balance != int.MinValue)
            {
            
                double convertedFunds = convertionCal.Convert(fundstodeposit, fundaccount.CurrencyCode, currencyCode);


                DocumentReference doc = db.Collection("users").Document(email).Collection("fundaccounts").Document(fundaccount.BankAccountNo);
                await doc.UpdateAsync("Balance", fundaccount.Balance + convertedFunds);


                return true;
            }

            return false;
        }


        public async Task<bool> depositfunds(string email, string bankaccountno, double funds)

        {
            double balance = getbalance(email,bankaccountno).Result;

            if( balance != int.MinValue)
            {
                DocumentReference doc = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
                await doc.UpdateAsync("Balance", balance + funds );



                return true;
            }

            return false;
        }
        private async Task<FundAccount> withdraw(string email, string bankaccountno, double amounttowithdraw)
         {
            double balance = getbalance(email, bankaccountno).Result;

            if (amounttowithdraw > balance)
            {
                return null;
            }

            if (balance != int.MinValue)
            {
                DocumentReference doc = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
                await doc.UpdateAsync("Balance", balance - amounttowithdraw);

                DocumentReference docfa = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
                DocumentSnapshot snapshot = await docfa.GetSnapshotAsync();
                FundAccount fundaccount = snapshot.ConvertTo<FundAccount>();
                return fundaccount;

                
            }

            return null;
        }


    }
}
