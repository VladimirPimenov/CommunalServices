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

			builder.Services.AddTransient<IAuthentificationRepository, AuthentificationRepository>();
			builder.Services.AddTransient<IFlatRepository, FlatRepository>();
			builder.Services.AddTransient<IDebtListRepository, DebtListRepository>();
			builder.Services.AddTransient<IDebtPaymentRepository, DebtPaymentRepository>();
			builder.Services.AddTransient<IReceiptRegistrationRepository, ReceiptRegistrationRepository>();

			builder.Services.AddTransient<IBankPaymentService, MockBankPaymentService>();
			builder.Services.AddTransient<IAbonentAuthenticationService, AbonentAuthenticationService>();
			builder.Services.AddTransient<IDebtPaymentService, DebtPaymentService>();
			builder.Services.AddTransient<IFlatDebtsQueryService, FlatDebtsQueryService>();
			builder.Services.AddTransient<IAbonentFlatsQueryService, AbonentFlatsQueryService>();
			builder.Services.AddTransient<INotificationService, EmailNotificationService>();
			builder.Services.AddTransient<IReceiptRegistrationService, AtolReceiptRegistrationService>();

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
