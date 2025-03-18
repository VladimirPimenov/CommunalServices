using CommunalServices.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Controllers
{
	[Route("/Flat")]
	[ApiController]
	public class FlatController(ApplicationDbContext dbContext) : Controller
	{
		[HttpGet("{abonentId:Guid}")]
		public IActionResult GetFlatsByAbonentId(Guid abonentId)
		{
			throw new NotImplementedException();
		}

		[HttpGet("{payNumber}")]
		public async Task<IActionResult> GetFlatByPaymentNumber(string payNumber)
		{
			var flat = await dbContext.Flat.FindAsync(payNumber);

			return flat == null ? NotFound() : Ok(flat);
		}
	}
}
