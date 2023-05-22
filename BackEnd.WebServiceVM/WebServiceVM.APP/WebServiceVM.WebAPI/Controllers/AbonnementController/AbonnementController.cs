using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence;
using WebServiceVM.WebAPI.Controllers.ParkingController;

namespace WebServiceVM.WebAPI.Controllers.AbonnementController
{
    public class AbonnementController : Controller
    {
        private readonly VMDbContext dbContext;
        public AbonnementController(VMDbContext dbContext) { this.dbContext = dbContext; }

        [HttpGet]
        [Route("AbonnementController")]
        public async Task<IActionResult> GetWebAbonnements()
        {
            return Ok(await dbContext.Abonnement.ToArrayAsync());
        }

        [HttpGet]
        [Route("AbonnementController/{id:guid}")]
        public async Task<IActionResult> GetWebAbonnement([FromRoute] Guid id)
        {
            var abonnement = await dbContext.Abonnement.FindAsync(id);
            if (abonnement == null)
            {
                return NotFound();
            }
            return Ok(abonnement);
        }

        [HttpPost]
        [Route("AbonnementController")]
        public async Task<IActionResult> AddAbonnement(AddAbonnementRequest addAbonnementRequest)
        {
            var abonnement = new Abonnement()
            {
                IdAbonnement = Guid.NewGuid(),
                DateCreation = addAbonnementRequest.DateCreation,
                DateActivation = addAbonnementRequest.DateActivation,
                DateDesActivation = addAbonnementRequest.DateDesActivation,
                Abonnee = addAbonnementRequest.Abonnee,
                TariffAbonnement = addAbonnementRequest.TariffAbonnement,
                //Payement = addAbonnementRequest.Payement,
            };
            await dbContext.Abonnement.AddAsync(abonnement);
            await dbContext.SaveChangesAsync();
            return Ok(abonnement);
        }
        [HttpPut]
        [Route("AbonnementController/{id:guid}")]
        public async Task<IActionResult> UpdateAbonnement([FromRoute] Guid id, UpdateAbonnementRequest updateAbonnementRequest)
        {
            var abonnement = await dbContext.Abonnement.FindAsync(id);
            if (abonnement != null)
            {
                abonnement.DateCreation = updateAbonnementRequest.DateCreation;
                abonnement.DateActivation = updateAbonnementRequest.DateActivation;
                abonnement.DateDesActivation = updateAbonnementRequest.DateDesActivation;
                abonnement.Abonnee = updateAbonnementRequest.Abonnee;
                abonnement.TariffAbonnement = updateAbonnementRequest.TariffAbonnement;
                //abonnement.Payement = updateAbonnementRequest.Payement;


                await dbContext.SaveChangesAsync();
                return Ok(abonnement);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("AbonnementController/{id:guid}")]
        public async Task<IActionResult> DeleteAbonnement([FromRoute] Guid id)
        {
            var abonnement = await dbContext.Abonnement.FindAsync(id);
            if (abonnement != null)
            {
                dbContext.Remove(abonnement);
                await dbContext.SaveChangesAsync();
                return Ok(abonnement);
            }
            return NotFound();

        }
    }
}
