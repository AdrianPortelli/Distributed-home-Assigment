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
            if (withdraw(email,backAccountNoWithdraw,fundstodeposit).Result == false)
            {
                return false;
            }

            if( depositfunds(email,backAccountNoDeposit,fundstodeposit).Result == false)
            {
                return false;
            }

            return true;
        }


        public async Task<int> sendFundsToSameDifferntOwner (string email, string emailDeposit, string backAccountNoWithdraw, string backAccountNoDeposit, double fundstodeposit)
        {
            // requires exchange rate
            DocumentReference doc = db.Collection("users").Document(emailDeposit);
            DocumentSnapshot snapshot = await doc.GetSnapshotAsync();
            if (snapshot.Exists)
            {

                if (withdraw(email, backAccountNoWithdraw, fundstodeposit).Result == false)
                {
                    return -1;
                }

                if (depositfunds(email, backAccountNoDeposit, fundstodeposit).Result == false)
                {
                    return -2;
                }

                return 1;

            }
            else
            {
                return 0;

            }

           
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
         private async Task<bool> withdraw(string email, string bankaccountno, double amounttowithdraw)
         {
            double balance = getbalance(email, bankaccountno).Result;

            if (amounttowithdraw > balance)
            {
                return false;
            }

            if (balance != int.MinValue)
            {
                DocumentReference doc = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
                await doc.UpdateAsync("Balance", balance - amounttowithdraw);

                return true;
            }

            return false;
        }
    }
}
