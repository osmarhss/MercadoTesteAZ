using MercadoTesteAZ.Models.Categorias;
using MercadoTesteAZ.Models.Clientes;
using MercadoTesteAZ.Models.Empresa;
using MercadoTesteAZ.Models.MeiosDePagamento;
using MercadoTesteAZ.Models.Pedidos;
using MercadoTesteAZ.Models.Produtos;
using MercadoTesteAZ.Models.SharedValues;
using MercadoTesteAZ.Models.Usuários;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Context
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
    }
}
