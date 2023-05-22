using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence;
using WebServiceVM.WebAPI.Controllers.TariffAbonnementController;

namespace WebServiceVM.WebAPI.Controllers.TariffTicketController
{
    public class TariffTicketController : Controller
    {
        private readonly VMDbContext dbContext;
        public TariffTicketController(VMDbContext dbContext) { this.dbContext = dbContext; }

        [HttpGet]
        [Route("TariffTicketController")]
        public async Task<IActionResult> GetTariffTickets()
        {
            return Ok(await dbContext.TariffAbonnement.ToArrayAsync());
        }

        [HttpGet]
        [Route("TariffTicketController/{id:guid}")]
        public async Task<IActionResult> GetTariffTicket([FromRoute] Guid id)
        {
            var tariffTicket = await dbContext.TariffTicket.FindAsync(id);
            if (tariffTicket == null)
            {
                return NotFound();
            }
            return Ok(tariffTicket);
        }

        [HttpPost]
        [Route("TariffTicketController")]
        public async Task<IActionResult> AddTariffTicket(AddTariffTicketRequest addTariffTicket)
        {
            var tariffTicket = new TariffTicket()
            {
                IdTariffTicket = Guid.NewGuid(),
                DateEntree = addTariffTicket.DateEntree,
                DateSortie = addTariffTicket.DateSortie,
                ListTicket = addTariffTicket.ListTicket,

            };
            await dbContext.TariffTicket.AddAsync(tariffTicket);
            await dbContext.SaveChangesAsync();
            return Ok(tariffTicket);
        }
        [HttpPut]
        [Route("TariffTicketController/{id:guid}")]
        public async Task<IActionResult> UpdateTariffTicket([FromRoute] Guid id, UpdateTariffTicketRequest updateTariffTicket)
        {
            var tariffTicket = await dbContext.TariffTicket.FindAsync(id);
            if (tariffTicket != null)
            {
                tariffTicket.DateEntree = updateTariffTicket.DateEntree;
                tariffTicket.DateSortie = updateTariffTicket.DateSortie;
                tariffTicket.ListTicket = updateTariffTicket.ListTicket;


                await dbContext.SaveChangesAsync();
                return Ok(tariffTicket);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("TariffTicketController/{id:guid}")]
        public async Task<IActionResult> DeleteTariffTicket([FromRoute] Guid id)
        {
            var tariffTicket = await dbContext.TariffTicket.FindAsync(id);
            if (tariffTicket != null)
            {
                dbContext.Remove(tariffTicket);
                await dbContext.SaveChangesAsync();
                return Ok(tariffTicket);
            }
            return NotFound();

        }
    }
}
