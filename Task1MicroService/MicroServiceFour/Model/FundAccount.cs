using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceFour.Model
{
    [FirestoreData]
    public class FundAccount
    {
        [FirestoreProperty]
        public string BankAccountNo { get; set; }

        [FirestoreProperty]
        public string Payee { get; set; }

        [FirestoreProperty]
        public string BankCode { get; set; }

        [FirestoreProperty]
        public string IBAN { get; set; }

        [FirestoreProperty]
        public string Country { get; set; }

        [FirestoreProperty]
        public string CurrencyCode { get; set; }

        [FirestoreProperty]
        public double OpeningBalance { get; set; }

        [FirestoreProperty]
        public double Balance { get; set; }

        [FirestoreProperty]
        public string Status { get; set; } // to check if status is disable or not-disabled

    }
}
