using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpmeetBackend.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UpmeetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEventController : ControllerBase
    {

        // GET api/<UserEventController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserFavEvents( int userId)
        {
           
            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {

                 var result = context.Users
                 .Where(x => x.UserId == userId)
                 .Include(x => x.UserEvents)
                 .ThenInclude(x => x.Event)
                 .ToList();


            }

            return Ok();

        }
        [HttpPost]
        public IActionResult UserFavEvents([FromBody] JObject json)
        { 
            UserEventDto request = JsonConvert.DeserializeObject<UserEventDto>(json.ToString());
            int userId = Int32.Parse(request.UserId);
            int eventId = Int32.Parse(request.EventId);

            User user = new User();
            Event eEvent = new Event();

            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {
                user = context.Users.Where(x => x.UserId == userId).FirstOrDefault();
                eEvent = context.Events.Where(x => x.EventId == eventId).FirstOrDefault();

                context.UserEvents.Add(new UserEvent() { UserId = userId,  EventId = eventId});

                if (context.SaveChanges() > 0)
                {
                    return Ok();
                }
                else return BadRequest("Nope");
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

