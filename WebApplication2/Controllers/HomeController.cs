﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Sevices;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILogic _service;

        public HomeController(ILogger<HomeController> logger, ILogic service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index(string inputText = "")
        {
            string text = _service.FindLetter(inputText);

            ViewData["text"] = text;

            return View();
        }

        public IActionResult Task()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}