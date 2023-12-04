using TradesDataManager.Services.CosmosDb;
using TradesDataManager.Services.RequestHandlers;

namespace TradesDataManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCosmosDbServices();
            builder.Services.AddRequestHandlers();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Could configure API versioning here using API.Versioning SDK 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}