using System.Linq;
using GigHub.Models;
using GigHub.ViewModels;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using Dapper;
using System.Data.SqlClient;
using System.Data.Entity;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();

            var viewModel = new GigsViewModel()
            {
                Heading = "Gigs I'm Attending",
                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View("Gigs",viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            using (var conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\_Sandbox\GigHub\GigHub\App_Data\aspnet-GigHub-20170307015550.mdf;Initial Catalog=aspnet-GigHub-20170307015550;Integrated Security=True"))
            {
                conn.Open();
                //var d = conn.Query<Doctor>("select * from hlc_Doctor").ToList();
                //var h = conn.Query<Hospital>("select * from hlc_Hospital").ToList();
                var u = conn.Query<User>("select * from hlc_User").ToList();
            }

            var d = new Doctor();

            //var d = new Doctor();
            //d.Attitude = Attitude.Favorable;

            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

                var gig = new Gig
                {
                    ArtistId = User.Identity.GetUserId(),
                    DateTime = viewModel.GetDateTime(),
                    GenreId = viewModel.Genre,
                    Venue = viewModel.Venue
                };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}