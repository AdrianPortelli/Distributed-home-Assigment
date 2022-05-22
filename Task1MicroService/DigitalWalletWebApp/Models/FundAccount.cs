
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.Models
{
  
    public class FundAccount
    {
        public string BankAccountNo { get; set; }
        public string Payee { get; set; }
        public string BankCode { get; set; }
        public string IBAN { get; set; }
        public string Country { get; set; }
        public string CurrencyCode { get; set; }
        public double OpeningBalance { get; set; }
        public double Balance { get; set; }
        public string Status { get; set; } // to check if status is disable or not-disabled

    }
}
