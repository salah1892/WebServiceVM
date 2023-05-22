using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence;
using WebServiceVM.WebAPI.Controllers.WebClientController;

namespace WebServiceVM.WebAPI.Controllers.AbonneeController
{
    public class AbonneeController : Controller
    {
        private readonly VMDbContext dbContext;
        public AbonneeController(VMDbContext dbContext) { this.dbContext = dbContext; }

        [HttpGet]
        [Route("AbonneeController")]
        public async Task<IActionResult> GetWebAbonnees()
        {
            return Ok(await dbContext.Abonnee.ToArrayAsync());
        }

        [HttpGet]
        [Route("AbonneeController/{id:guid}")]
        public async Task<IActionResult> GetWebAbonnee([FromRoute] Guid id)
        {
            var abonnee = await dbContext.Abonnee.FindAsync(id);
            if (abonnee == null)
            {
                return NotFound();
            }
            return Ok(abonnee);
        }

        [HttpPost]
        [Route("AbonneeController")]
        public async Task<IActionResult> AddWebAbonnee(AddAbonneeRequest addAbonneeRequest)
        {
            var abonnee = new Abonnee()
            {
                IdAbonnee = Guid.NewGuid(),
                NumCarte = addAbonneeRequest.NumCarte,
                Nom = addAbonneeRequest.Nom,
                Prenom = addAbonneeRequest.Prenom,
                Abonnement = addAbonneeRequest.Abonnement,
            };
            await dbContext.Abonnee.AddAsync(abonnee);
            await dbContext.SaveChangesAsync();
            return Ok(abonnee);
        }
        [HttpPut]
        [Route("AbonneeController/{id:guid}")]
        public async Task<IActionResult> UpdateWebClient([FromRoute] Guid id, UpdateAbonneeRequest updateAbonneeRequest)
        {
            var abonnee = await dbContext.Abonnee.FindAsync(id);
            if (abonnee != null)
            {
                abonnee.NumCarte = updateAbonneeRequest.NumCarte;
                abonnee.Nom = updateAbonneeRequest.Nom;
                abonnee.Prenom = updateAbonneeRequest.Prenom;
                abonnee.Abonnement = updateAbonneeRequest.Abonnement;

                await dbContext.SaveChangesAsync();
                return Ok(abonnee);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("AbonneeController/{id:guid}")]
        public async Task<IActionResult> DeleteAbonnee([FromRoute] Guid id)
        {
            var abonnee = await dbContext.Abonnee.FindAsync(id);
            if (abonnee != null)
            {
                dbContext.Remove(abonnee);
                await dbContext.SaveChangesAsync();
                return Ok(abonnee);
            }
            return NotFound();

        }
    }
}
