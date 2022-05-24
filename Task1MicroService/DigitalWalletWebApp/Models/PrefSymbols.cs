using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace DigitalWalletWebApp.Models
{
    [FirestoreData]
    public class PrefSymbols
    {
        [FirestoreProperty]
        public string symbols { get; set; }

    }
}
