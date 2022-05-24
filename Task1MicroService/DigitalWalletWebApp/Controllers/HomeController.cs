using DigitalWalletWebApp.DataAccess;
using DigitalWalletWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFireStoreDataAccess _firestore;
        private PubSubDataAccess pubSubDataAccess = new PubSubDataAccess(); 
        public HomeController(ILogger<HomeController> logger,IFireStoreDataAccess firestore)
        {
            _logger = logger;
            _firestore = firestore;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> LogIn()
        {
            await pubSubDataAccess.Publish_Info_LastestTweets(new Models.User { Email = User.Claims.ElementAt(4).Value });
            PrefSymbols prefSymbols = await _firestore.getPrefCurrenies(User.Claims.ElementAt(4).Value);

            await pubSubDataAccess.Publish_Info_LastestExchangeRates(new PrefExchangeRates { Email = User.Claims.ElementAt(4).Value, Symbols = prefSymbols.symbols });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> viewLastestNews()
        {
             LatestNew ln = await _firestore.getLatestNews(User.Claims.ElementAt(4).Value);

            return View(ln);
        }

        [Authorize]
        [HttpGet]
        public IActionResult savePrefSymbols()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> savePrefSymbols(PrefSymbols prefSymbols)
        {
            await _firestore.savePrefCurrecnies(User.Claims.ElementAt(4).Value, prefSymbols);

            PrefSymbols ps = await _firestore.getPrefCurrenies(User.Claims.ElementAt(4).Value);

            await pubSubDataAccess.Publish_Info_LastestExchangeRates(new PrefExchangeRates { Email = User.Claims.ElementAt(4).Value, Symbols = ps.symbols });

            return View();
        }

    }
}
