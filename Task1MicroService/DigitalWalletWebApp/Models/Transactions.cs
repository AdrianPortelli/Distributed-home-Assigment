using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.Model
{
    
    public class Transactions
    {

        public string ID { get; set; }

        public string Email { get; set; }

        public DateTime TranscationDateTime { get; set; }

        public string TranscationType { get; set; }

        public string AccountNo { get; set; }

        public string FundsTransferedSameOwnerAccountNo { get; set; }

        public string FundsTransferedtoIBAN { get; set; }

        public double Funds { get; set; }


    }
}
