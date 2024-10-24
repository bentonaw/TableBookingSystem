
using Microsoft.EntityFrameworkCore;
using TableBookingSystem.Data;
using TableBookingSystem.Data.Repo;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Mappings;
using TableBookingSystem.Services;
using TableBookingSystem.Services.IService;

namespace TableBookingSystem
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var services = builder.Services;

			services.AddDbContext<TableBookingSystemContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

            

            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("LocalReact", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			services.AddScoped<ICustomerRepo, CustomerRepo>();
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<IReservationRepo, ReservationRepo>();
			services.AddScoped<IReservationService, ReservationService>();
			services.AddScoped<IMenuRepo, MenuRepo>();
			services.AddScoped<IMenuService, MenuService>();
			services.AddScoped<ITableReservationRepo, TableReservationRepo>();


			services.AddAutoMapper(typeof(MappingProfile).Assembly);

			var app = builder.Build();

            app.UseCors("LocalReact");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
