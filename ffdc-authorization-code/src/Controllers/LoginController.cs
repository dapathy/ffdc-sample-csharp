﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ffdc_authorization_code.Services;

namespace ffdc_authorization_code.Controllers
{
    public class LoginController : Controller
    {
        private FFDCClientService _ffdcClientService;

        public LoginController(FFDCClientService ffdcClientService)
        {
            _ffdcClientService = ffdcClientService;
        }

        [Route("login")]
        public IActionResult Index()
        {
            ViewBag.isStrong = _ffdcClientService.GetIsStrongValue();
            string authCodeurl = _ffdcClientService.GetFFDCAuthCodeUri();
            return Redirect(authCodeurl);
        }

        [Route("callback")]
        public IActionResult GenerateAccessToken(string code)
        {
            bool strong = _ffdcClientService.GetIsStrongValue();
            ViewBag.isStrong = strong;
            string token = _ffdcClientService.GenerateToken(code, strong);
            if (!string.IsNullOrEmpty(token))
            {
                HttpContext.Session.SetString("token", token);
                return View("auth", token);
            }
        
            return View("error", "Unauthorized!");
        }

        [Route("logout")]
        public IActionResult logOut()
        {
            ViewBag.isStrong = _ffdcClientService.GetIsStrongValue();
            HttpContext.Session.Remove("token");
            return View("logout");
        }

        public IActionResult Error(string message)
        {
            return View("error", message);
        }
    }
}