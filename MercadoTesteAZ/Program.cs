using FluentValidation;
using FluentValidation.AspNetCore;
using MercadoTesteAZ.Application.AppServices.Aggregations;
using MercadoTesteAZ.Application.AppServices.Auth;
using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.AppServices.Categorias;
using MercadoTesteAZ.Application.AppServices.Empresas.Vendedores;
using MercadoTesteAZ.Application.AppServices.MeiosDePagamento;
using MercadoTesteAZ.Application.AppServices.Produtos;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Categorias;
using MercadoTesteAZ.Application.Mappings.ContasBancárias;
using MercadoTesteAZ.Application.Mappings.HistoricoPrecos;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.Mappings.Produtos;
using MercadoTesteAZ.Application.Mappings.Vendedores;
using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Domain.Entities.Usuários;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Categorias;
using MercadoTesteAZ.Infra.Repositories.Clientes;
using MercadoTesteAZ.Infra.Repositories.Empresa;
using MercadoTesteAZ.Infra.Repositories.Pagamentos;
using MercadoTesteAZ.Infra.Repositories.Produtos;  
using MercadoTesteAZ.Presentation.Extensions;
using MercadoTesteAZ.Presentation.Validators;
using MercadoTesteAZ.Presentation.ViewModels.Categorias;
using MercadoTesteAZ.Presentation.ViewModels.ContasBancarias;
using MercadoTesteAZ.Presentation.ViewModels.HistoricosDePreco;
using MercadoTesteAZ.Presentation.ViewModels.Produtos;
using MercadoTesteAZ.Presentation.ViewModels.Vendedores;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            builder.Services.AddScoped(typeof(IAppServiceReadOnly<,>), typeof(AppServiceReadOnly<,>));
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IContaBancariaRepository, ContaBancariaRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();
            builder.Services.AddScoped<ITransportadoraRepository, TransportadoraRepository>();
            builder.Services.AddScoped<IProdutoAppService<ProdutoVendedorViewModel, ProdutoDraft, Produto>, ProdutoAppService>();
            builder.Services.AddScoped<IProdutoAppServiceReadOnly<ProdutoConsumidorViewModel, Produto>, ProdutoAppServiceReadOnly>();
            builder.Services.AddScoped<ICategoriaAppService<CategoriaAdminViewModel, CategoriaDraft, Categoria>, CategoriaAppService>();
            builder.Services.AddScoped<ICategoriaAppServiceReadOnly<CategoriaConsumidorViewModel, Categoria>, CategoriaAppServiceReadOnly>();
            builder.Services.AddScoped<IProdutoAppServiceReadOnly<ProdutoConsumidorViewModel, Produto>, ProdutoAppServiceReadOnly>();
            builder.Services.AddScoped<IVendedorAppService, VendedorAppService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IContaBancariaAppService, ContaBancariaAppService>();
            builder.Services.AddScoped<IVendedorOrquestradorService, VendedorOrquestradorService>();
            builder.Services.AddScoped<IMapper<CategoriaAdminViewModel, CategoriaDraft, Categoria>, CategoriaMapper>();
            builder.Services.AddScoped<IMapperToViewModel<CategoriaConsumidorViewModel, Categoria>, CategoriaConsumidorMapper>();
            builder.Services.AddScoped<IMapperToViewModel<ProdutoConsumidorViewModel, Produto>, ProdutoConsumidorMapper>();
            builder.Services.AddScoped<IMapper<ProdutoVendedorViewModel, ProdutoDraft, Produto>, ProdutoVendedorMapper>();
            builder.Services.AddScoped<IMapper<VendedorViewModel, VendedorDraft, Vendedor>, VendedorMapping>();
            builder.Services.AddScoped<IMapper<ContaBancariaViewModel, ContaBancariaDraft, ContaBancaria>, ContaBancariaMapper>();
            builder.Services.AddScoped<IMapperToViewModel<HistoricoPrecoViewModel, HistoricoPreco>, HistoricoPrecoMapper>();
            builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<AppDbContext>().
                AddDefaultTokenProviders();

            string mySqlConecction = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConecction, ServerVersion.AutoDetect(mySqlConecction)));

            var secretKey = builder.Configuration["JWT:SecretKey"] ?? throw new ArgumentException("Key inválida");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("Vendor", policy => policy.RequireRole("Vendor"));
                options.AddPolicy("User", policy => policy.RequireRole("User"));
                options.AddPolicy("VendorManager", policy => policy.RequireRole("Vendor", "Admin"));
                options.AddPolicy("UserManager", policy => policy.RequireRole("User", "Admin"));
            });

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
            app.UseMiddleware<ExceptionMiddleware>();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
