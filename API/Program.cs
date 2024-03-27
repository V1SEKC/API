using API.Data;
using API.Handler;
using API.Repositories;
using API.Repositories.Implementations;
using API.Services;
using API.Services.Implementations;
using API.Validators;
using API.Validators.Implementation;
using ConsoleApp1.Repositories;
using ConsoleApp1.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<AppDbContext>(
				options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			builder.Services.AddScoped<IComputerRepository, ComputerRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IUserService, UserServiceImpl>();
			builder.Services.AddScoped<IApontmentRepository, ApontmentRepository>();
			//Не вижу инстансов для остальных валидаторов
			builder.Services.AddScoped<IUserValidator, UserValidatorImpl>();
			builder.Services.AddScoped<IComputerValidator, ComputerValidatorImpl>();
			builder.Services.AddScoped<IApontmentValidator, ApontmentValidatorImpl>();
			builder.Services.AddControllers();

			//Регистрируем хендлеры
			builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
			builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();
			app.UseExceptionHandler("/error");
			app.Run();
		}
	}
}