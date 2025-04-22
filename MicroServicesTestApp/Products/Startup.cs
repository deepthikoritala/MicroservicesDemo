using Common;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Products.DBContexts;
using Products.Repository;

namespace Products
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var pgSqlConnectionBuilder = new NpgsqlConnectionStringBuilder()
            {
                Host = "localhost",
                Port = 5432,
                Username = "postgres",
                Password = "postgres",
                Database = "microservice_demo"
            };

            services.AddConsulConfig(Configuration);
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddDbContext<ProductContext>(o => o.UseNpgsql(pgSqlConnectionBuilder.ConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProductContext>();
                context.Database.Migrate();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseConsul(Configuration);
        }
    }
}