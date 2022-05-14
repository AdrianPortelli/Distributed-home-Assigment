using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask2.Model
{
    [FirestoreData]
    public class FundAccount
    {
        [FirestoreProperty]
        public string BankAccoutNo { get; set; }

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
        public string OpeningBalance { get; set; }

    }
}
