using Helpdesk_api.Dto;
using Helpdesk_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Ahmet_Ergun_Helpdesk_api.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{id:int}", Name = "GetTicketRoute")]
        public async Task<IActionResult> GetTicketById([FromRoute] int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketCreateRequest model)
        {
            var serviceResult = await _ticketService.CreateTicketAsync(model);
            if (!serviceResult.IsSuccess || serviceResult.Result == null)
            {
                return Ok(serviceResult);
            }

            return CreatedAtRoute("GetTicketRoute", new { id = serviceResult.Result.Id }, serviceResult);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] int id, [FromBody] TicketUpdateRequest model)
        {
            var serviceResult = await _ticketService.UpdateTicketAsync(id, model);
            return Ok(serviceResult);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            var serviceResult = await _ticketService.DeleteTicketAsync(id);
            return Ok(serviceResult);
        }
    }
}
