using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
	[Route("/Abonent")]
	[ApiController]
	public class AbonentController(ApplicationDbContext dbContext) : ControllerBase
	{
		[HttpGet("{id:Guid}")]
		public IActionResult GetAbonentById(Guid id)
		{
			var abonent = dbContext.Abonent.Find(id);

			return abonent == null ? NotFound() : Ok(abonent);
		}

		[HttpGet("{login}")]
		public IActionResult GetAbonentByLogin(string login)
		{
			var abonent = dbContext.Abonent.FirstOrDefault(abonent => abonent.Login == login);

			return abonent == null ? NotFound() : Ok(abonent);
		}

		[HttpPost]
		public IActionResult AddAbonent(Abonent abonent)
		{
			dbContext.Abonent.Add(abonent);
			dbContext.SaveChanges();

			return Ok(abonent);
		}

		[HttpPut("{abonentId:Guid}")]
		public IActionResult UpdateAbonent(Guid abonentId, Abonent updatedAbonent)
		{
			var abonent = dbContext.Abonent.Find(abonentId);

			if(abonent == null)
			{
				return NotFound();
			}
			else
			{
				abonent.Login = updatedAbonent.Login;
				abonent.Password = updatedAbonent.Password;
				abonent.Email = updatedAbonent.Email;

				dbContext.SaveChanges();

				return Ok(abonent);
			}
		}

		[HttpDelete("{abonentId:Guid}")]
		public IActionResult DeleteAbonent(Guid abonentId)
		{
			Abonent? abonent = dbContext.Abonent.Find(abonentId);

			if(abonent == null) return NotFound();

			dbContext.Abonent.Remove(abonent);
			dbContext.SaveChanges();

			return Ok(abonentId);
		}
	}
}
