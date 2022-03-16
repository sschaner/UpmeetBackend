using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpmeetBackend.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UpmeetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEventController : ControllerBase
    {
        private readonly UpmeetBackendContext _context;
        public UserEventController(UpmeetBackendContext context)
        {
            _context = context;
        }


        // GET api/<UserEventController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Event>> UserFavEvents(int userId)
        {

            //User user = _context.Users.Where(x=>x.UserId == userId).FirstOrDefault();



            //_context.Entry(user).Collection(x=>x.UserEvents).Load();

            List<Event> favEvents = new List<Event>();

            var events = _context.Users
                .Where(u => u.UserId == userId)
                .Include(u => u.UserEvents)
                    .ThenInclude(ue => ue.Event)
                .ToList();

            foreach(var item in events)
            {
                foreach(var eEvent in item.UserEvents)
                {
                    favEvents.Add(_context.Events.Where(x=>x.EventId == eEvent.EventId).FirstOrDefault());
                }
               
               // yield return new Event { UserId = item.UserId, Event = item };
            }

            return favEvents;


        }

        // POST api/<UserEventController>
        [HttpPost]
        public static void UserFavEvents(int userId, int eventId)
        {
            User user = new User();
            Event eEvent = new Event();

            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {
                user = context.Users.Where(x => x.UserId == userId).FirstOrDefault();
                eEvent = context.Events.Where(x => x.EventId == eventId).FirstOrDefault();

                context.UserEvents.Add(new UserEvent() { UserId = userId, User = user, EventId = eventId, Event = eEvent });
                context.SaveChanges();
            }
        }

        // DELETE api/<UserEventController>/5
        [HttpDelete("{id}")]
        public void Delete(int userId, int eventId)
        {
            UserEvent userEvent = new UserEvent();

            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {
                userEvent = context.UserEvents.Where(x => x.UserId == userId).Where(x => x.EventId == eventId).FirstOrDefault();
                context.UserEvents.Remove(userEvent);
                context.SaveChanges();
            }
        }
    }
}
