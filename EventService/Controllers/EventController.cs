using Microsoft.AspNetCore.Mvc;
using EventService.Models;
using EventService.Services;

namespace EventService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventPublisher _publisher = new();

        [HttpPost]
        public IActionResult CreateEvent([FromBody] Event ev)
        {
            ev.Id = Guid.NewGuid();
            _publisher.PublishEvent(ev);
            return Ok(new { status = "Event created and scheduled notification sent", eventId = ev.Id });
        }
    }
}
