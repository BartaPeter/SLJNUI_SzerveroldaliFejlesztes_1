
using Microsoft.EntityFrameworkCore;
using SLJNUI_DunaVizallas.Data;

namespace SLJNUI_DunaVizallas.EndPoint
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

            builder.Services.AddDbContext<DunaVizallasContext>(opt =>
            {
                opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SLJNUI_DunaVizallas;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
            });

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

            app.Run();
        }
    }
}
