using member.Models;
using member.Models.BLO;
using member.NewFolder.NewFolder;
using member.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace member.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemberBLO MemberBLO;

        public HomeController(ILogger<HomeController> logger, IMemberBLO _MemberBLO)
        {
            _logger = logger;
            MemberBLO = _MemberBLO;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string account, string password)
        {
            password = CryptoService.Encrypt(password);
            Member member = MemberBLO.GetByParam(account, password);
            if (member == null)
            {   
                ViewBag.Message = "帳密錯誤，請重新輸入";
                return View();
            }
            HttpContext.Session.SetString("Success", member.Name + "你好!");
            

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Member item)

        {
            item.Password=CryptoService.Encrypt(item.Password);
            MemberBLO.Create(item);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
