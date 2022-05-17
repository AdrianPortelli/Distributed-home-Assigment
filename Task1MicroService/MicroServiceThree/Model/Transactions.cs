using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceThree.Model
{
    [FirestoreData]
    public class Transactions
    {
        [FirestoreProperty]
        public string Email { get; set; }

     
        [FirestoreProperty]
        public string TranscationType { get; set; }

        [FirestoreProperty]
        public string AccountNo { get; set; }

        [FirestoreProperty]
        public string FundsTransferedSameOwnerAccountNo { get; set; }

        [FirestoreProperty]
        public string FundsTransferedtoIBAN { get; set; }

        [FirestoreProperty]
        public double Funds { get; set; }


    }
}
