using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Entities.Clientes;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Entities.Pedidos;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Domain.Entities.SharedValues;
using MercadoTesteAZ.Domain.Entities.Usuário;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Infra.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<MeusDadosPagamento> MeusDadosPagamentos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<CartaoDeCredito> CartoesDeCredito { get; set; }
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<PayPal> ContasPayPal { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }
        public DbSet<HistoricoPreco> HistoricosDePreco { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<DadosContato> DadosContatos { get; set; }
        public DbSet<DadosGeograficos> DadosGeograficos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoProduto>()
                .HasKey(pp => new { pp.PedidoId, pp.ProdutoId });

            modelBuilder.Entity<PedidoProduto>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.ProdutosComprados)
                .HasForeignKey(pp => pp.PedidoId);

            modelBuilder.Entity<PedidoProduto>()
                .HasOne(pp => pp.Produto)
                .WithMany()
                .HasForeignKey(pp => pp.ProdutoId);
        }

    }
}
