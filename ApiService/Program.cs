using ApiService.Data;
using ApiService.Services.CarService;
using ApiService.Services.RedisService;
using ApiService.Services.SeedingService;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace ApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load Redis configuration from appsettings.json
            var redisConnectionString = builder.Configuration.GetSection("Redis:ConnectionString").Value;

            // Configure Redis connection options
            var configurationOptions = ConfigurationOptions.Parse(redisConnectionString);
            configurationOptions.AbortOnConnectFail = false;
            configurationOptions.ConnectTimeout = 10000;  // 10 seconds
            configurationOptions.SyncTimeout = 10000;     // 10 seconds

            // Register Redis connection multiplexer as a singleton
            builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                return ConnectionMultiplexer.Connect(configurationOptions);
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
            });

            builder.Services.AddTransient<ISeedingService, SeedingService>();
            builder.Services.AddTransient<ICarService, CarService>();
            builder.Services.AddTransient<IRedisService, RedisService>();

            var app = builder.Build();

            // Test Redis connection and set/get a key
            app.MapGet("/", async (IConnectionMultiplexer redis) =>
            {
                var db = redis.GetDatabase();
                await db.StringSetAsync("mykey", "Hello, Redis!");
                var value = await db.StringGetAsync("mykey");
                return Results.Ok(value.ToString());
            });

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
