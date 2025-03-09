using CommunalServices.Data;
using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
	[Route("/Abonent")]
	[ApiController]
	public class AbonentController : ControllerBase
	{
		private ApplicationDbContext dbContext;
		public AbonentController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpGet("{id:Guid}")]
		public IActionResult GetAbonentById(Guid id)
		{
			Abonent? abonent = dbContext.Abonent.Find(id);

			if (abonent == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(abonent);
			}
		}

		[HttpGet("{login}")]
		public IActionResult GetAbonentByLogin(string login)
		{
			var abonent = dbContext.Abonent.FirstOrDefault(abonent => abonent.Login == login);

			if(abonent == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(abonent);
			}
		}

		//[HttpGet]
		//public IActionResult GetAllAbonents()
		//{
		//	var abonents = context.Abonents.ToList();

		//	return Ok(abonents);
		//}

		[HttpPost]
		public IActionResult AddAbonent(Abonent abonent)
		{
			dbContext.Abonent.Add(abonent);
			dbContext.SaveChanges();
			return Ok();
		}

		[HttpPut("{id:Guid}")]
		public IActionResult UpdateAbonent(Guid id, Abonent updatedAbonent)
		{
			Abonent? abonent = dbContext.Abonent.Find(id);

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

				return Ok();
			}
		}

		[HttpDelete ("{id:Guid}")]
		public IActionResult DeleteAbonent(Guid id)
		{
			Abonent? abonent = dbContext.Abonent.Find(id);

			if(abonent == null)
			{
				return NotFound();
			}
			else
			{
				dbContext.Abonent.Remove(abonent);
				dbContext.SaveChanges();

				return Ok();
			}
		}
	}
}
