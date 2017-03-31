using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.Controllers.Api
{
    //[Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            //var userId =  User.Identity.GetUserId();  //
            var userId = "a20cc1ad-ac9a-45a5-95b5-a87689f9e663";
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }
    }
}
