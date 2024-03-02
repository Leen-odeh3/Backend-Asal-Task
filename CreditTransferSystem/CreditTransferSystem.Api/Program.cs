using CreditTransferSystem.Domain.IGenericRepository;
using CreditTransferSystem.Infrastructure.Data;
using CreditTransferSystem.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;


namespace CreditTransferSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(
           builder.Configuration.GetConnectionString("Default")
            ));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()); 
            app.MapControllers();

            app.Run();
        }
    }
}
