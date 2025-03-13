using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
	[Route("/Flat")]
	[ApiController]
	public class FlatController(ApplicationDbContext dbContext) : Controller
	{
		[HttpGet("{ownerId:Guid}")]
		public IActionResult GetFlatsByOwnerId(Guid ownerId)
		{
			var flats = dbContext.Flat.Where(flat => flat.OwnerId == ownerId).ToList();

			if(flats.Count == 0)
			{
				return NotFound();
			}
			else
			{
				return Ok(flats);
			}
		}

		[HttpGet("{payNumber}")]
		public IActionResult GetFlatByPaymentNumber(string payNumber)
		{
			var flat = dbContext.Flat.Find(payNumber);

			return flat == null ? NotFound() : Ok(flat);
		}
	}
}
