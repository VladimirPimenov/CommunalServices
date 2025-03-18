using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Controllers
{
	[Route("/Abonent")]
	[ApiController]
	public class AbonentController(ApplicationDbContext dbContext) : ControllerBase
	{
		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetAbonentById(Guid id)
		{
			var abonent = await dbContext.Abonent.FindAsync(id);

			return abonent == null ? NotFound() : Ok(abonent);
		}

		[HttpGet("{login}")]
		public async Task<IActionResult> GetAbonentByLogin(string login)
		{
			var abonent = await dbContext.Abonent.FirstOrDefaultAsync(abonent => abonent.Login == login);

			return abonent == null ? NotFound() : Ok(abonent);
		}

		[HttpPost]
		public async Task<IActionResult> AddAbonent(AbonentDTO abonent)
		{
			await dbContext.Abonent.AddAsync(abonent.ConvertToAbonent());
			await dbContext.SaveChangesAsync();

			return Ok(abonent);
		}

		[HttpPut("{abonentId:Guid}")]
		public async Task<IActionResult> UpdateAbonent(Guid abonentId, AbonentDTO updatedAbonent)
		{
			var abonent = await dbContext.Abonent.FindAsync(abonentId);

			if (abonent == null) return NotFound();

            abonent.Login = updatedAbonent.Login;
            abonent.Password = updatedAbonent.Password;
            abonent.Email = updatedAbonent.Email;
            await dbContext.SaveChangesAsync();

			return Ok(abonent);
		}

		[HttpDelete("{abonentId:Guid}")]
		public async Task<IActionResult> DeleteAbonent(Guid abonentId)
		{
			var abonent = await dbContext.Abonent.FindAsync(abonentId);

			if(abonent == null) return NotFound();

			dbContext.Abonent.Remove(abonent);
			await dbContext.SaveChangesAsync();

			return Ok(abonentId);
		}
	}
}