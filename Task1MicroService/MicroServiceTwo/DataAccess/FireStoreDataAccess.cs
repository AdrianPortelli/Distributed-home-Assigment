using Google.Cloud.Firestore;
using MicroServiceTwo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTwo.DataAccess
{
    public class FireStoreDataAccess : IFireStoreDataAccess
    {
        private FirestoreDb db { get; set; }

        public FireStoreDataAccess(string project)
        {
            db = FirestoreDb.Create(project);
        }

        public async void AddFundAccount(User user, FundAccount fundAccount)
        {

            var document = await db.Collection("users").Document(user.Email).GetSnapshotAsync();
            if (document.Exists)
            {
                DocumentReference doc = db.Collection("users").Document(user.Email).Collection("fundaccounts").Document(fundAccount.BankAccountNo);
                await doc.SetAsync(fundAccount);

                return;
            }

            DocumentReference docRef = db.Collection("users").Document(user.Email);
            await docRef.SetAsync(user);

            DocumentReference docReffundac = db.Collection("users").Document(user.Email).Collection("fundaccounts").Document(fundAccount.BankAccountNo);
            await docReffundac.SetAsync(fundAccount);

        }

        public async Task<bool> DisableFundAccount(string email, string bankaccountno)
        {
            var document = await db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno).GetSnapshotAsync();
            if (document.Exists)
            {
                DocumentReference docRef = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
                await docRef.UpdateAsync("Status", "disabled");

                return true;
            }

            return false;
        }

        public async Task<List<FundAccount>> GetFundAccounts(string email)
        {

            var document = await db.Collection("users").Document(email).GetSnapshotAsync();
            if (!document.Exists)
            {
                
                return new List<FundAccount>();
            }

            Query fundquery = db.Collection("users").Document(email).Collection("fundaccounts");
            QuerySnapshot fundQuerySnapshot = await fundquery.GetSnapshotAsync();

            List<FundAccount> fundaccounts = new List<FundAccount>();

            foreach (DocumentSnapshot documentSnapshot in fundQuerySnapshot)
            {
                fundaccounts.Add(documentSnapshot.ConvertTo<FundAccount>());
            }

            return fundaccounts;

        }

        public async Task<FundAccount> GetFundAccount(string email, string bankaccountno)
        {
          
                DocumentReference docRef = db.Collection("users").Document(email).Collection("fundaccounts").Document(bankaccountno);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    FundAccount fundaccount = snapshot.ConvertTo<FundAccount>();
                    return fundaccount;

                }
                else
                {
                    return null;

                }
         
        }
    }
}
