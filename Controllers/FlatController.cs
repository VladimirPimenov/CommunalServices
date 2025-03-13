using CommunalServices.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
	[Route("/Flat")]
	[ApiController]
	public class FlatController(ApplicationDbContext dbContext) : Controller
	{
		[HttpGet("{abonentId:Guid}")]
		public IActionResult GetFlatsByOwnerId(Guid abonentId)
		{
			var flats = dbContext.Flat.Where(flat => flat.AbonentId == abonentId).ToList();

			return flats.Count == 0 ? NotFound() : Ok(flats);
		}

		[HttpGet("{payNumber}")]
		public IActionResult GetFlatByPaymentNumber(string payNumber)
		{
			var flat = dbContext.Flat.Find(payNumber);

			return flat == null ? NotFound() : Ok(flat);
		}
	}
}
