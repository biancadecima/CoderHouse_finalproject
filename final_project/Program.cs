namespace final_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
            SqlHandler.ConnectionString = connectionString;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(policy =>
            {
                policy.AddDefaultPolicy(options =>
                options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(action => action.AllowAnyOrigin());

            app.MapControllers();

            app.Run();
        }
    }
}