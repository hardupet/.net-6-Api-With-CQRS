using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSchedule.Library.Commands;
using RestaurantSchedule.Library.Models;
using RestaurantSchedule.Library.Queries;
using static RestaurantSchedule.Library.Commands.AddSchedule;

namespace RestaurantSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IMediator _mediator;
        public ScheduleController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/getSchedule")]
        public async Task<IActionResult> GetSchedule()
        {
            var query = new GetScheduleQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("/addSchedule")]
        public async Task<WeeklyScheduleResponse> PostSchedule([FromBody] WeeklySchedule weeklySchedule)
        {
            var schedule = new AddSchedule(weeklySchedule);
            return await _mediator.Send(schedule);
        }
    }
}
