using DigitalWalletWebApp.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.DataAccess
{
    public class FireStoreDataAccess : IFireStoreDataAccess
    {
        private FirestoreDb db { get; set; }

        public FireStoreDataAccess(string project)
        {
            db = FirestoreDb.Create(project);
        }

        public async Task<LatestNew> getLatestNews(string email)
        {

            DocumentReference docRef = db.Collection("users").Document(email).Collection("latestnews").Document("currentnews");
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {

                LatestNew latestNew = snapshot.ConvertTo<LatestNew>();
                return latestNew;

            }
            else
            {
                return null;

            }


        }

        public async Task<WriteResult> savePrefCurrecnies(string email,  PrefSymbols prefSymbols)
        {
            DocumentReference docRef = db.Collection("users").Document(email).Collection("prefexchangerate").Document("pref");
            return await docRef.SetAsync(prefSymbols);
        }


        public async Task<PrefSymbols> getPrefCurrenies(string email)
        {
            DocumentReference docRef = db.Collection("users").Document(email).Collection("prefexchangerate").Document("pref");
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                PrefSymbols prefSymbols = snapshot.ConvertTo<PrefSymbols>();
                return prefSymbols;

            }
            else
            {
                return null;

            }
        }
    }
}
