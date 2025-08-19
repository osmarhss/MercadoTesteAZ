using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Enums;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MercadoTesteAZ.Domain.Entities.MeiosDePagamento
{
    public class ContaBancaria : IEntity
    {
        protected ContaBancaria() { }

        private ContaBancaria(string id, string instituicaoBancaria, int tipoConta, string agencia, string numConta, bool contaPrincipal, string vendedorId) 
        {
            Id = id;
            InstituicaoBancaria = instituicaoBancaria;
            TipoConta = (TipoContaBancaria)tipoConta;
            Agencia = agencia;
            NumConta = numConta;
            ContaPrincipal = contaPrincipal;
            VendedorId = vendedorId;
        }

        public string Id { get; private set; }
        public string InstituicaoBancaria { get; private set; }
        public TipoContaBancaria TipoConta { get; private set; }
        public string Agencia { get; private set; }
        public string NumConta { get; private set; }
        public bool ContaPrincipal { get; private set; }
        public string VendedorId { get; private set; }
        public Vendedor? Vendedor { get; private set; }

        public static ContaBancaria Criar(string id, string instituicaoBancaria, int tipoConta, string agencia, string numConta, bool contaPrincipal, string vendedorId) 
            => new ContaBancaria(id, instituicaoBancaria, tipoConta, agencia, numConta, contaPrincipal, vendedorId);

        public static ContaBancaria AdicionarEntidade(string instituicaoBancaria, int tipoConta, string agencia, string numConta, bool contaPrincipal, string vendedorId)
            => new ContaBancaria(Guid.NewGuid().ToString("D"), instituicaoBancaria, tipoConta, agencia, numConta, contaPrincipal, vendedorId);
    }
}
