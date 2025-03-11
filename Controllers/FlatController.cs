using CommunalServices.Data;
using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
	[Route("/Flat")]
	[ApiController]
	public class FlatController : Controller
	{
		private ApplicationDbContext dbContext;

		public FlatController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

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

		[HttpGet("{number}")]
		public IActionResult GetFlatByPaymentNumber(string number)
		{
			Flat? flat = dbContext.Flat.Find(number);

			if (flat == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(flat);
			}
		}
	}
}
