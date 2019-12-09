﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarPartsStore.Data.Models;
using CarPartsStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarPartsStore.Controllers
{
    public class HomeController : Controller
    {
        private CarPartContext db;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, CarPartContext context)
        {
            _logger = logger;
            db = context;
        }
        public async Task<IActionResult> Indexing()
        {
            return View(await db.CarParts.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarPart carPart)
        {
            db.CarParts.Add(carPart);
            await db.SaveChangesAsync();
            return RedirectToAction("Indexing");
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}