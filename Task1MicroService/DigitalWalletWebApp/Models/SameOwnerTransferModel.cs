using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.Models
{
    public class SameOwnerTransferModel
    {
        public string DepositAccountNo { get; set; }
        public string WithrdrawBacnkAccountNo { get; set; }
        public double Funds { get; set; }
    }
}
