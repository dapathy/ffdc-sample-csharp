﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using ffdc_authorization_code.Services;
using System;

namespace ffdc_authorization_code.Controllers
{
    public class DataController : Controller
    {
        private FFDCClientService _ffdcClientService;

        public DataController(FFDCClientService ffdcClientService)
        {
            _ffdcClientService = ffdcClientService;
        }

        [Route("results")]
        public IActionResult Index()
        {
            ViewBag.isStrong = _ffdcClientService.GetIsStrongValue();
            string token = HttpContext.Session.GetString("token");
            int responseCode = 200;
            if (string.IsNullOrEmpty(token))
            {
                return View("~/Views/Login/error.cshtml", "Unauthorized!");
            }
            var result = _ffdcClientService.GetResults(token, out responseCode);
            if(responseCode==200)
                return View("results", result);
            else
            {
                return View("~/Views/Login/error.cshtml", "Unauthorized!");
            }

        }

    }
}