using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.Models
{
    public class ConvertionCalModel
    {

        public string BaseSymbol { get; set; }

        public string SymbolToConvertTo { get; set; }
        public double Amount { get; set; }

        public double Result { get; set; }
    }
}
