using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence;

namespace WebServiceVM.WebAPI.Controllers.WebClientController
{
    public class WebClientController : Controller
    {
        private readonly VMDbContext dbContext;
        public WebClientController(VMDbContext dbContext) { this.dbContext = dbContext; }
        
        [HttpGet]
        [Route("WebClientController")]
        public async Task<IActionResult> GetWebClients()
        {
            return Ok(await dbContext.WebClient.ToArrayAsync());
        }

        [HttpGet]
        [Route("WebClientController/{id:guid}")]
        public async Task<IActionResult> GetWebClient([FromRoute] Guid id)
        {
            var webClient = await dbContext.WebClient.FindAsync(id);
            if (webClient == null)
            {
                return NotFound();
            }
            return Ok(webClient);
        }

        [HttpPost]
        [Route("WebClientController")]
        public async Task<IActionResult> AddWebClient(AddWebClientRequest addWebClientRequest)
        {
            var webClient = new WebClient()
            {
                IdWebClient = Guid.NewGuid(),
                FirstName = addWebClientRequest.FirstName,
                LastName= addWebClientRequest.LastName,
                Email = addWebClientRequest.Email,
                Mobile = addWebClientRequest.Mobile,
                Password = addWebClientRequest.Password,
                
            };
            await dbContext.WebClient.AddAsync(webClient);
            await dbContext.SaveChangesAsync();
            return Ok(webClient);
        }
        [HttpPut]
        [Route("WebClientController/{id:guid}")]
        public async Task<IActionResult> UpdateWebClient([FromRoute] Guid id, UpdateWebClientRequest updateWebClientRequest)
        {
            var webClient = await dbContext.WebClient.FindAsync(id);
            if (webClient != null)
            {
                webClient.FirstName = updateWebClientRequest.FirstName;
                webClient.LastName = updateWebClientRequest.LastName;
                webClient.Email = updateWebClientRequest.Email;
                webClient.Mobile = updateWebClientRequest.Mobile;
                webClient.Password = updateWebClientRequest.Password;

                await dbContext.SaveChangesAsync();
                return Ok(webClient);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("WebClientController/{id:guid}")]
        public async Task<IActionResult> DeleteWebClient([FromRoute] Guid id)
        {
            var webClient = await dbContext.WebClient.FindAsync(id);
            if (webClient != null)
            {
                dbContext.Remove(webClient);
                await dbContext.SaveChangesAsync();
                return Ok(webClient);
            }
            return NotFound();

        }
    }
}
