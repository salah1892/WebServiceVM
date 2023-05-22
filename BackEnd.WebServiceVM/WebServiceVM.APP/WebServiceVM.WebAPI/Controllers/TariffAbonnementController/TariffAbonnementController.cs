using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence;
using WebServiceVM.WebAPI.Controllers.PayementController;

namespace WebServiceVM.WebAPI.Controllers.TariffAbonnementController
{
    public class TariffAbonnementController : Controller
    {
        private readonly VMDbContext dbContext;
    public TariffAbonnementController(VMDbContext dbContext) { this.dbContext = dbContext; }

    [HttpGet]
    [Route("TariffAbonnementController")]
    public async Task<IActionResult> GetTariffAbonnements()
    {
        return Ok(await dbContext.TariffAbonnement.ToArrayAsync());
    }

    [HttpGet]
    [Route("TariffAbonnementController/{id:guid}")]
    public async Task<IActionResult> GetTariffAbonnement([FromRoute] Guid id)
    {
        var tariffAbonnement = await dbContext.TariffAbonnement.FindAsync(id);
        if (tariffAbonnement == null)
        {
            return NotFound();
        }
        return Ok(tariffAbonnement);
    }

    [HttpPost]
    [Route("TariffAbonnementController")]
    public async Task<IActionResult> AddTariffAbonnement(AddTariffAbonnementRequest addTariffAbonnement)
    {
        var tariffAbonnement = new TariffAbonnement()
        {
            IdTariffAbonnement = Guid.NewGuid(),
            TypeAbonnement = addTariffAbonnement.TypeAbonnement,
            DateDebut = addTariffAbonnement.DateDebut,
            DateFin = addTariffAbonnement.DateFin,
            ListAbonnements = addTariffAbonnement.ListAbonnements,
            ListParkings = addTariffAbonnement.ListParkings,

        };
        await dbContext.TariffAbonnement.AddAsync(tariffAbonnement);
        await dbContext.SaveChangesAsync();
        return Ok(tariffAbonnement);
    }
    [HttpPut]
    [Route("TariffAbonnementController/{id:guid}")]
    public async Task<IActionResult> UpdateTariffAbonnement([FromRoute] Guid id, UpdateTariffAbonnementRequest updateTariffAbonnement)
    {
        var tariffAbonnement = await dbContext.TariffAbonnement.FindAsync(id);
        if (tariffAbonnement != null)
        {
                tariffAbonnement.TypeAbonnement = updateTariffAbonnement.TypeAbonnement;
                tariffAbonnement.DateDebut = updateTariffAbonnement.DateDebut;
                tariffAbonnement.DateFin = updateTariffAbonnement.DateFin;
                tariffAbonnement.ListAbonnements = updateTariffAbonnement.ListAbonnements;
                tariffAbonnement.ListParkings = updateTariffAbonnement.ListParkings;

            await dbContext.SaveChangesAsync();
            return Ok(tariffAbonnement);
        }
        return NotFound();
    }
    [HttpDelete]
    [Route("TariffAbonnementController/{id:guid}")]
    public async Task<IActionResult> DeleteTariffAbonnement([FromRoute] Guid id)
    {
        var tariffAbonnement = await dbContext.TariffAbonnement.FindAsync(id);
        if (tariffAbonnement != null)
        {
            dbContext.Remove(tariffAbonnement);
            await dbContext.SaveChangesAsync();
            return Ok(tariffAbonnement);
        }
        return NotFound();

    }
}
}
