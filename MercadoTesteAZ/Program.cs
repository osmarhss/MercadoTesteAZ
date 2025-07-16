using FluentValidation;
using FluentValidation.AspNetCore;
using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Application.Repositories.Categorias;
using MercadoTesteAZ.Application.Repositories.Clientes;
using MercadoTesteAZ.Application.Services;
using MercadoTesteAZ.Application.Services.Categorias;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Presentation.Validators;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddValidatorsFromAssemblyContaining<CategoriaValidator>().AddFluentValidationAutoValidation();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<ICategoriaService, CategoriaService>();
            builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

            string mySqlConecction = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConecction, ServerVersion.AutoDetect(mySqlConecction)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
