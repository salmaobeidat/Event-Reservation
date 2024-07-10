using EventReservation.API.NswagConfig;
using EventReservation.core.ICommon;
using EventReservation.core.IRepository;
using EventReservation.core.IService;
using EventReservation.infra.Common;
using EventReservation.infra.Repository;
using EventReservation.infra.Service;

namespace EventReservation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddOpenApiDocument((configure, sp) =>
            {
                configure.Title = "SampleProject API";
                //define naming of method in nswag generated client
                configure.OperationProcessors.Add(new FlattenOperationsProcessor());

            });

            builder.Services.AddScoped<IDbContext, DbContext>();

            builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IUsersService, UsersService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUi(settings =>
                {
                    settings.Path = "/api";
                    settings.DocumentPath = "/api/specification.json";
                });
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}