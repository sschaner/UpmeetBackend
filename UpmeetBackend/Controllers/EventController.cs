using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpmeetBackend.Models;

namespace UpmeetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        // GET: api/<EventController>
        [HttpGet]
        public List<Event> GetAllEvents()
        {
            List<Event> result = null;
            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {
                result = context.Events.ToList();
            }

            return result;
        }

        // GET api/<UserController>/id
        [HttpGet("{id}")]
        public Event GetEventById(int id)
        {
            List<Event> result = null;
            Event upMeet = null;
            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {
                result = context.Events.ToList();
                // [id - 1] but [id - 1000] if the table auto increments, starting at 1000.
                upMeet = result[id - 1];
            }

            return upMeet;
        }

        // This method adds to the Events table using Postman but the auto increment of the UserId starts at 1000
        [HttpPost]
        public Event SaveEvent(Event upMeet)
        {
            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {
                context.Events.Add(upMeet);
                context.SaveChanges();
            }
            return upMeet;
        }
    }
}
