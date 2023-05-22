using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence;

namespace WebServiceVM.WebAPI.Controllers.ParkingController
{
    public class ParkingController : Controller
    {
        private readonly VMDbContext dbContext;
        public ParkingController(VMDbContext dbContext) { this.dbContext = dbContext; }

        [HttpGet]
        [Route("ParkingController")]
        public async Task<IActionResult> GetWebParkings()
        {
            return Ok(await dbContext.Parking.ToArrayAsync());
        }

        [HttpGet]
        [Route("ParkingController/{id:guid}")]
        public async Task<IActionResult> GetWebParking([FromRoute] Guid id)
        {
            var parking = await dbContext.Parking.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }
            return Ok(parking);
        }

        [HttpPost]
        [Route("ParkingController")]
        public async Task<IActionResult> AddTicket(AddParkingRequest addParkingRequest)
        {
            var parking = new Parking()
            {
                IdParking = Guid.NewGuid(),
                NomParking = addParkingRequest.NomParking,
                TypeParking = addParkingRequest.TypeParking,
                AdressParking = addParkingRequest.AdressParking,
                ListTariffAbonnement = addParkingRequest.ListTariffAbonnement,
            };
            await dbContext.Parking.AddAsync(parking);
            await dbContext.SaveChangesAsync();
            return Ok(parking);
        }
        [HttpPut]
        [Route("ParkingController/{id:guid}")]
        public async Task<IActionResult> UpdateParking([FromRoute] Guid id, UpdateParkingRequest updateParkingRequest)
        {
            var parking = await dbContext.Parking.FindAsync(id);
            if (parking != null)
            {
                parking.NomParking = updateParkingRequest.NomParking;
                parking.TypeParking = updateParkingRequest.TypeParking;
                parking.AdressParking = updateParkingRequest.AdressParking;
                parking.ListTariffAbonnement = updateParkingRequest.ListTariffAbonnement;


                await dbContext.SaveChangesAsync();
                return Ok(parking);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("ParkingController/{id:guid}")]
        public async Task<IActionResult> DeleteParking([FromRoute] Guid id)
        {
            var parking = await dbContext.Parking.FindAsync(id);
            if (parking != null)
            {
                dbContext.Remove(parking);
                await dbContext.SaveChangesAsync();
                return Ok(parking);
            }
            return NotFound();

        }
    }
}
