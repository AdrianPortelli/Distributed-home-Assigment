using Google.Cloud.Firestore;
using MicroServiceFour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceFour.DataAccess
{
    public class FireStoreDataAccess : IFireStoreDataAccess
    {

        private FirestoreDb db { get; set; }

        public FireStoreDataAccess(string project)
        {
            db = FirestoreDb.Create(project);
        }

        public async Task<List<Transactions>> getAllTranscations(string email)
        {
            List<Transactions> users = new List<Transactions>();
            Query document =  db.Collection("transactions").Document(email).Collection("fundaccounttransactions").WhereEqualTo("Email",email);
            QuerySnapshot allusers = await document.GetSnapshotAsync();


            foreach (DocumentSnapshot documentSnapshot in allusers.Documents)
            {
                users.Add(documentSnapshot.ConvertTo<Transactions>());
            }

            return users;
            // users instead of fundaccounts
        }

        public async Task<List<Transactions>> getTranscationsForSpecificAccount(string email,string accountno)
        {
            List<Transactions> users = new List<Transactions>();
            Query document = db.Collection("transactions").Document(email).Collection("fundaccounttransactions").WhereEqualTo("AccountNo", accountno);
            QuerySnapshot allusers = await document.GetSnapshotAsync();


            foreach (DocumentSnapshot documentSnapshot in allusers.Documents)
            {
                users.Add(documentSnapshot.ConvertTo<Transactions>());
            }

            return users;
        }

        public async Task<List<Transactions>> GetTransactionsByDateRange(string email, DateTime start,DateTime end)
        {
            List<Transactions> users = new List<Transactions>();
            Query document = db.Collection("transactions").Document(email).Collection("fundaccounttransactions").WhereGreaterThanOrEqualTo("TranscationDateTime",start).WhereLessThanOrEqualTo("TranscationDateTime",end);
            QuerySnapshot allusers = await document.GetSnapshotAsync();


            foreach (DocumentSnapshot documentSnapshot in allusers.Documents)
            {
                users.Add(documentSnapshot.ConvertTo<Transactions>());
            }

            return users;
        }



    }
}
