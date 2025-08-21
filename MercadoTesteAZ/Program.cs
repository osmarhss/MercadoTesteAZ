using FluentValidation;
using FluentValidation.AspNetCore;
using MercadoTesteAZ.Application.AppServices.Aggregations;
using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.AppServices.Categorias;
using MercadoTesteAZ.Application.AppServices.Empresas.Vendedores;
using MercadoTesteAZ.Application.AppServices.Produtos;
using MercadoTesteAZ.Application.AppServices.Usuarios;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Categorias;
using MercadoTesteAZ.Application.Mappings.ContasBancárias;
using MercadoTesteAZ.Application.Mappings.HistoricoPrecos;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.Mappings.Produtos;
using MercadoTesteAZ.Application.Mappings.Usuarios;
using MercadoTesteAZ.Application.Mappings.Vendedores;
using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Domain.Entities.Usuário;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Categorias;
using MercadoTesteAZ.Infra.Repositories.Clientes;
using MercadoTesteAZ.Infra.Repositories.Empresa;
using MercadoTesteAZ.Infra.Repositories.Produtos;
using MercadoTesteAZ.Infra.Repositories.Usuarios;
using MercadoTesteAZ.Presentation.Validators;
using MercadoTesteAZ.Presentation.ViewModels.Categorias;
using MercadoTesteAZ.Presentation.ViewModels.ContasBancarias;
using MercadoTesteAZ.Presentation.ViewModels.HistoricosDePreco;
using MercadoTesteAZ.Presentation.ViewModels.Produtos;
using MercadoTesteAZ.Presentation.ViewModels.Usuarios;
using MercadoTesteAZ.Presentation.ViewModels.Vendedores;
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
            builder.Services.AddScoped(typeof(IAppServiceReadOnly<,>), typeof(AppServiceReadOnly<,>));
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IProdutoAppService<ProdutoVendedorViewModel, ProdutoDraft, Produto>, ProdutoAppService>();
            builder.Services.AddScoped<IProdutoAppServiceReadOnly<ProdutoConsumidorViewModel, Produto>, ProdutoAppServiceReadOnly>();
            builder.Services.AddScoped<ICategoriaAppService<CategoriaAdminViewModel, CategoriaDraft, Categoria>, CategoriaAppService>();
            builder.Services.AddScoped<ICategoriaAppServiceReadOnly<CategoriaConsumidorViewModel, Categoria>, CategoriaAppServiceReadOnly>();
            builder.Services.AddScoped<IProdutoAppServiceReadOnly<ProdutoConsumidorViewModel, Produto>, ProdutoAppServiceReadOnly>();
            builder.Services.AddScoped<IVendedorAppService, VendedorAppService>();
            builder.Services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            builder.Services.AddScoped<IVendedorOrquestradorService, VendedorOrquestradorService>();
            builder.Services.AddScoped<IMapper<CategoriaAdminViewModel, CategoriaDraft, Categoria>, CategoriaMapper>();
            builder.Services.AddScoped<IMapperToViewModel<CategoriaConsumidorViewModel, Categoria>, CategoriaConsumidorMapper>();
            builder.Services.AddScoped<IMapperToViewModel<ProdutoConsumidorViewModel, Produto>, ProdutoConsumidorMapper>();
            builder.Services.AddScoped<IMapper<ProdutoVendedorViewModel, ProdutoDraft, Produto>, ProdutoVendedorMapper>();
            builder.Services.AddScoped<IMapper<VendedorViewModel, VendedorDraft, Vendedor>, VendedorMapping>();
            builder.Services.AddScoped<IMapper<ContaBancariaViewModel, ContaBancariaDraft, ContaBancaria>, ContaBancariaMapper>();
            builder.Services.AddScoped<IMapper<UsuarioViewModel, UsuarioDraft, Usuario>, UsuarioMapper>();
            builder.Services.AddScoped<IMapperToViewModel<HistoricoPrecoViewModel, HistoricoPreco>, HistoricoPrecoMapper>();
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
