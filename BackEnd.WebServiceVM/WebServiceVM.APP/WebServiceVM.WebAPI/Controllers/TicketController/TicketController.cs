using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence;
using WebServiceVM.WebAPI.Controllers.AbonneeController;

namespace WebServiceVM.WebAPI.Controllers.TicketController
{
    public class TicketController : Controller
    {
        private readonly VMDbContext dbContext;
        public TicketController(VMDbContext dbContext) { this.dbContext = dbContext; }

        [HttpGet]
        [Route("TicketController")]
        public async Task<IActionResult> GetWebTickets()
        {
            return Ok(await dbContext.Ticket.ToArrayAsync());
        }

        [HttpGet]
        [Route("TicketController/{id:guid}")]
        public async Task<IActionResult> GetWebTicket([FromRoute] Guid id)
        {
            var abonnee = await dbContext.Abonnee.FindAsync(id);
            if (abonnee == null)
            {
                return NotFound();
            }
            return Ok(abonnee);
        }

        [HttpPost]
        [Route("TicketController")]
        public async Task<IActionResult> AddTicket(AddTicketRequest addTicketRequest)
        {
            var ticket = new Ticket()
            { IdTicket = Guid.NewGuid(),
                Statut = addTicketRequest.Statut,
                DateEntree = addTicketRequest.DateEntree,
                DateSortie = addTicketRequest.DateSortie,
                PrixTicket = addTicketRequest.PrixTicket,
                TariffTicket = addTicketRequest.TariffTicket,
                //Payement=addTicketRequest.Payement,
            };
            await dbContext.Ticket.AddAsync(ticket);
            await dbContext.SaveChangesAsync();
            return Ok(ticket);
        }
        [HttpPut]
        [Route("TicketController/{id:guid}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] Guid id, UpdateTicketRequest updateTicketRequest)
        {
            var ticket = await dbContext.Ticket.FindAsync(id);
            if (ticket != null)
            {
                ticket.Statut = updateTicketRequest.Statut;
                ticket.DateEntree = updateTicketRequest.DateEntree;
                ticket.DateSortie = updateTicketRequest.DateSortie;
                ticket.PrixTicket = updateTicketRequest.PrixTicket;
                ticket.TariffTicket = updateTicketRequest.TariffTicket;
                //ticket.Payement = updateTicketRequest.Payement;

                await dbContext.SaveChangesAsync();
                return Ok(ticket);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("TicketController/{id:guid}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] Guid id)
        {
            var ticket = await dbContext.Ticket.FindAsync(id);
            if (ticket != null)
            {
                dbContext.Remove(ticket);
                await dbContext.SaveChangesAsync();
                return Ok(ticket);
            }
            return NotFound();

        }
    }
}
