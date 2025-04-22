using Common;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Orders.DBContexts;
using Orders.Repository;
using Products.Repository;

namespace Orders
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
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddDbContext<OrdersContext>(o => o.UseNpgsql(pgSqlConnectionBuilder.ConnectionString));

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

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<OrdersContext>();
                context.Database.Migrate();
            }

            app.UseConsul(Configuration);
        }
    }
}