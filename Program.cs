using CommunalServices.Domain;
using CommunalServices.Storage;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<IRepository, Repository>();
			builder.Services.AddScoped<IAbonentLogger, AbonentLogger>();

            var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.MapControllers();

            app.Run();
		}
	}
}
