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

        public async Task<int> getbalance(string email, string backaccountno)
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
        public async Task<bool> depositfunds(string email, string bankaccountno, int funds)

        {
            int balance = getbalance(email,bankaccountno).Result;

            if( balance != int.MinValue)
            {
                DocumentReference doc = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
                await doc.UpdateAsync("Balance", balance + funds );

                return true;
            }

            return false;
        }
    }
}
