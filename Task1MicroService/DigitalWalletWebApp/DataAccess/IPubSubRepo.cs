using DigitalWalletWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.DataAccess
{
    public interface IPubSubRepo
    {
        Task<string> Publish_Info_LastestExchangeRates(PrefExchangeRates prefExchangeRates);

        Task<string> Publish_Info_LastestTweets(User user);

    }
}
