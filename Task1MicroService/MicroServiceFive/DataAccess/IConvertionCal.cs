using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceFive.DataAccess
{
    public interface IConvertionCal
    {

       
        double Convert(double funds, string basecur, string symbol);
    }
}
