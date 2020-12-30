using member.Models;
using member.Models.BLO;
using member.NewFolder.NewFolder;
using member.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
        // 會員登入
        [HttpPost]
        public async Task<IActionResult> Login(string account, string password)
        {
            password = CryptoService.Encrypt(password);
            Member member = MemberBLO.GetByParam(account, password);
            if (member == null)
            {
                ViewBag.Message = "帳密錯誤，請重新輸入";
                return View();
            }
            


            var claims = new List<Claim>
            {
                new Claim("FullName", member.Name),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties { };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        // 會員註冊
        [HttpPost]
        public IActionResult Register(Member item)

        {

            Member member = MemberBLO.RepeatAccount(item.Account);
            if (member != null)
            {
                ViewBag.Message = "此帳號重複，請重新輸入";
                return View();
            }
            item.Password = CryptoService.Encrypt(item.Password);
            MemberBLO.Create(item);
            return View();
        }
        // 會員登出
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
