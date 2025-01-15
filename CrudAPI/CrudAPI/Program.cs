
using CrudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI
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
            //var provider = builder.Services.BuildServiceProvider();
            //var config = provider.GetRequiredService<IConfiguration>();
            //builder.Services.AddDbContext<AmndbContext>(item => item.UseSqlServer(config.GetConnectionString("amdb")));
            var provider = builder.Services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();
            builder.Services.AddDbContext<AmndbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("amdb")));

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
