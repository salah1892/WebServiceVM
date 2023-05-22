using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence;
using WebServiceVM.WebAPI.Controllers.AbonneeController;

namespace WebServiceVM.WebAPI.Controllers.PayementController
{
    public class PayementController : Controller
    {
        private readonly VMDbContext dbContext;
        public PayementController(VMDbContext dbContext) { this.dbContext = dbContext; }

        [HttpGet]
        [Route("PayementController")]
        public async Task<IActionResult> GetPayements()
        {
            return Ok(await dbContext.Payement.ToArrayAsync());
        }

        [HttpGet]
        [Route("PayementController/{id:guid}")]
        public async Task<IActionResult> GetPayement([FromRoute] Guid id)
        {
            var payement = await dbContext.Payement.FindAsync(id);
            if (payement == null)
            {
                return NotFound();
            }
            return Ok(payement);
        }

        [HttpPost]
        [Route("PayementController")]
        public async Task<IActionResult> AddPayement(AddPayementRequest addPayementRequest)
        {
            var payement = new Payement()
            {
                IdPayement = Guid.NewGuid(),
                DatePayement = addPayementRequest.DatePayement,
                Abonnement = addPayementRequest.Abonnement,
                Ticket = addPayementRequest.Ticket,
               
            };
            await dbContext.Payement.AddAsync(payement);
            await dbContext.SaveChangesAsync();
            return Ok(payement);
        }
        [HttpPut]
        [Route("PayementController/{id:guid}")]
        public async Task<IActionResult> UpdatePayement([FromRoute] Guid id, UpdatePayementRequest updatePayementRequest)
        {
            var payement = await dbContext.Payement.FindAsync(id);
            if (payement != null)
            {
                payement.DatePayement = updatePayementRequest.DatePayement;
                payement.Abonnement = updatePayementRequest.Abonnement;
                payement.Ticket = updatePayementRequest.Ticket;

                await dbContext.SaveChangesAsync();
                return Ok(payement);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("PayementController/{id:guid}")]
        public async Task<IActionResult> DeletePayement([FromRoute] Guid id)
        {
            var payement = await dbContext.Payement.FindAsync(id);
            if (payement != null)
            {
                dbContext.Remove(payement);
                await dbContext.SaveChangesAsync();
                return Ok(payement);
            }
            return NotFound();

        }
    }

}
