using Microsoft.AspNetCore.Mvc;
using Login.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Repositories.Data;
using Microsoft.AspNetCore.Http;

namespace Login.Controlles
{
    public class AccountControllers : Controller
    {
        AccountRepository accountRepository;

        public AccountControllers(AccountRepository accountRepository)
        {
            this.accountRepository=accountRepository;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login (Logins logins)
        {
            var data = accountRepository.Login(logins);
            if (data != null)
            {
                HttpContext.Session.SetString("Role", data.Role);
                return RedirectToAction("Index", "Kota");
            }
            return View();
        }
    }
}
