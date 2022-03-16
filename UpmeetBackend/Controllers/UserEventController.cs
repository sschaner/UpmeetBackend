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

        // GET api/<UserEventController>/5
        [HttpGet("{id:int}")]
    
        public IEnumerable<Event> GetUserFavEvents( int userId)
        {
            List<Event> favEvents = new List<Event>();
            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {

                favEvents = context.Events.Where(e => e.UserEvents.Any(u => u.UserId == userId)).ToList();

                foreach (Event eEvnt in favEvents)
                {

                }

            }
            return favEvents;

        }
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

