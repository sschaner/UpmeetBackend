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

        // GET api/<EventController>/id
        [HttpGet("{id}")]
        public Event GetEventById(int id)
        {
            Event upMeet = new Event();
            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {
                upMeet = context.Events.Where(x => x.EventId == id).FirstOrDefault();
            }

            return upMeet;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event updatedEvent)
        {
            List<Event> result = null;
            Event upMeetEvent = null;
            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {
                result = context.Events.ToList();
                upMeetEvent = result.Where(x => x.EventId == id).FirstOrDefault();
                upMeetEvent.Title = updatedEvent.Title;
                upMeetEvent.Host = updatedEvent.Host;
                upMeetEvent.Description = updatedEvent.Description;
                upMeetEvent.Location = updatedEvent.Location;
                upMeetEvent.Start = updatedEvent.Start;
                upMeetEvent.End = updatedEvent.End;
                context.SaveChanges();
            }
        }

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


        [HttpDelete("{id}")]
        public Event RemoveEventById(int id)
        {
            Event upMeet = new Event();
            using (UpmeetBackendContext context = new UpmeetBackendContext())
            {
                upMeet = context.Events.Where(x => x.EventId == id).FirstOrDefault();
                context.Events.Remove(upMeet);
                context.SaveChanges();
            }
            return upMeet;
        }
    }
}
