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

        public async Task<double> getbalance(string email, string backaccountno)
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


        public  bool sendFundsToSameOwner(string email, string backAccountNoWithdraw, string backAccountNoDeposit, double fundstodeposit)
        {
            // requires exchange rate
            FundAccount withdrawAccount = withdraw(email, backAccountNoWithdraw, fundstodeposit).Result;

            if (withdrawAccount != null)
            {
               return depositFundsFromAnotherAccount(email, backAccountNoDeposit, fundstodeposit, withdrawAccount.CurrencyCode).Result;
            }

            return false;
          
        }


        public  bool depositFundsToSameDifferntOwner (string email, string emailDeposit, string backAccountNoWithdraw, string backAccountNoDeposit, double fundstodeposit)
        {
            // requires exchange rate

            FundAccount withdrawAccount = withdraw(email, backAccountNoWithdraw, fundstodeposit).Result;

            if (withdrawAccount != null)
            {
                return depositFundsFromAnotherAccount(emailDeposit, backAccountNoDeposit, fundstodeposit, withdrawAccount.CurrencyCode).Result;
            }

            return false;



        }

        public async Task<bool> depositFundsFromAnotherAccount(string email, string bankaccountno, double fundstodeposit, string currencyCode)
        {
            double balance = getbalance(email, bankaccountno).Result;
            if (balance != int.MinValue)
            {

                DocumentReference docfa = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
                DocumentSnapshot snapshot = await docfa.GetSnapshotAsync();
                FundAccount fundaccount = snapshot.ConvertTo<FundAccount>();

                double convertedFunds = convertionCal.Convert(fundstodeposit, fundaccount.CurrencyCode, currencyCode);


                DocumentReference doc = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
                await doc.UpdateAsync("Balance", balance + convertedFunds);


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
