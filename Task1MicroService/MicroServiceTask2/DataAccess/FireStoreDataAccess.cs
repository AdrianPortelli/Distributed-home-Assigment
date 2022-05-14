using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using MicroServiceTask2.Model;

namespace MicroServiceTask2.DataAccess
{
    public class FireStoreDataAccess : IFireStoreDataAccess
    {
        private FirestoreDb db { get; set; }

        public FireStoreDataAccess(string project)
        {
            db = FirestoreDb.Create(project);
        }

        public async void AddFundAccount(User user,FundAccount fundAccount)
        {

            var document = await db.Collection("users").Document(user.Email).GetSnapshotAsync();
            if (document.Exists)
            {
                DocumentReference doc = db.Collection("users").Document(user.Email).Collection("fundaccounts").Document(fundAccount.BankAccoutNo);
                await doc.SetAsync(fundAccount);

                return;
            }

            DocumentReference docRef = db.Collection("users").Document(user.Email);
            await docRef.SetAsync(user);

            DocumentReference docReffundac = db.Collection("users").Document(user.Email).Collection("fundaccounts").Document(fundAccount.BankAccoutNo);
            await docReffundac.SetAsync(fundAccount);

        }
    }
}
