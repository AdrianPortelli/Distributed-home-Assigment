using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.Models
{
    public class TransferToDifferentOwner
    {
       public string IBAN { get; set; }
       public string DepositEmail { get; set; }
       public string WithdrawEmail { get; set; }
       public string WithdrawBackAccountNo { get; set; }
       public double Funds { get; set; }

    }
}
