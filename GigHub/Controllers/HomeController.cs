﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                .Include(global => global.Artist)
                .Include(global => global.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);

            var viewModel = new GigsViewModel
            {
                Heading = "Upcoming Gigs",
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}