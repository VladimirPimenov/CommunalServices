using Microsoft.EntityFrameworkCore;

using CommunalServices.Domain.Repositories;
using CommunalServices.Storage;
using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.UseCase;

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

			builder.Services.AddDbContext<CommunalServicesPaymentContext>(options =>
			options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<IAuthentificationRepository, AuthentificationRepository>();
			builder.Services.AddScoped<IFlatRepository, FlatRepository>();
			builder.Services.AddScoped<IDebtListRepository, DebtListRepository>();
			builder.Services.AddScoped<IDebtPaymentRepository, DebtPaymentRepository>();
			builder.Services.AddScoped<IReceiptRegistrationRepository, ReceiptRegistrationRepository>();

			builder.Services.AddScoped<IBankPaymentService, MockBankPaymentService>();
			builder.Services.AddScoped<IAbonentAuthenticationService, AbonentAuthenticationService>();
			builder.Services.AddScoped<IDebtPaymentService, DebtPaymentService>();
			builder.Services.AddScoped<IFlatDebtsQueryService, FlatDebtsQueryService>();
			builder.Services.AddScoped<IAbonentFlatsQueryService, AbonentFlatsQueryService>();
			builder.Services.AddScoped<INotificationService, EmailNotificationService>();
			builder.Services.AddScoped<IReceiptRegistrationService, AtolReceiptRegistrationService>();

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
