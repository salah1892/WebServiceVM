using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence;
using WebServiceVM.WebAPI.Controllers.WebClientController;

namespace WebServiceVM.WebAPI.Controllers.ParametreController
{
    public class ParametreController : Controller
    {
        private readonly VMDbContext dbContext;
        public ParametreController(VMDbContext dbContext) { this.dbContext = dbContext; }

        [HttpGet]
        [Route("ParametreController")]
        public async Task<IActionResult> GetParametres()
        {
            return Ok(await dbContext.Parametre.ToArrayAsync());
        }
        [HttpGet]
        [Route("ParametreController/{id:guid}")]
        public async Task<IActionResult> GetParametre([FromRoute] Guid id)
        {
            var parametre = await dbContext.Parametre.FindAsync(id);
            if (parametre == null)
            {
                return NotFound();
            }
            return Ok(parametre);
        }
        [HttpPost]
        [Route("ParametreController")]
        public async Task<IActionResult> AddParametre(AddParametreRequest addParametreRequest)
        {
            var parametre = new Parametre()
            {
                IdParametre = Guid.NewGuid(),
                TypePayement=addParametreRequest.TypePayement,
                DescriptionPayement=addParametreRequest.DescriptionPayement

            };
            await dbContext.Parametre.AddAsync(parametre);
            await dbContext.SaveChangesAsync();
            return Ok(parametre);
        }
        [HttpPut]
        [Route("ParametreController/{id:guid}")]
        public async Task<IActionResult> UpdateParametre([FromRoute] Guid id, UpdateParametreRequest updateParametreRequest)
        {
            var parametre = await dbContext.Parametre.FindAsync(id);
            if (parametre != null)
            {
                parametre.TypePayement = updateParametreRequest.TypePayement;
                parametre.DescriptionPayement = updateParametreRequest.DescriptionPayement;
                 await dbContext.SaveChangesAsync();
                return Ok(parametre);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("ParametreController/{id:guid}")]
        public async Task<IActionResult> DeleteParametre([FromRoute] Guid id)
        {
            var parametre = await dbContext.Parametre.FindAsync(id);
            if (parametre != null)
            {
                dbContext.Remove(parametre);
                await dbContext.SaveChangesAsync();
                return Ok(parametre);
            }
            return NotFound();

        }
    }
}
