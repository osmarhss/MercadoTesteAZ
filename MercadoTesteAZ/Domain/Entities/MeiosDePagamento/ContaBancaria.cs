using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Enums;

namespace MercadoTesteAZ.Domain.Entities.MeiosDePagamento
{
    public class ContaBancaria : IEntity
    {
        protected ContaBancaria() { }

        private ContaBancaria(string id, string cnpj, string instituicaoBancaria, TipoContaBancaria tipoConta, string agencia, string numConta, bool contaPrincipal, string vendedorId, TipoEmpresa tipoEmpresa) 
        {
            Id = id;
            Cnpj = cnpj;
            InstituicaoBancaria = instituicaoBancaria;
            TipoConta = tipoConta;
            Agencia = agencia;
            NumConta = numConta;
            ContaPrincipal = contaPrincipal;
            ProprietarioId = vendedorId;
            TipoEmpresa = tipoEmpresa;
        }

        public string Id { get; private set; }
        public string Cnpj { get; private set; }
        public string InstituicaoBancaria { get; private set; }
        public TipoContaBancaria TipoConta { get; private set; }
        public string Agencia { get; private set; }
        public string NumConta { get; private set; }
        public bool ContaPrincipal { get; private set; }
        public string ProprietarioId { get; private set; }
        public TipoEmpresa TipoEmpresa { get; private set; }

        public static ContaBancaria Adicionar(string cnpj, string instituicaoBancaria, TipoContaBancaria tipoConta, string agencia, string numConta, bool contaPrincipal, string proprietarioId, TipoEmpresa tipoEmpresa)
            => new ContaBancaria(Guid.NewGuid().ToString("D"), cnpj, instituicaoBancaria, tipoConta, agencia, numConta, contaPrincipal, proprietarioId, tipoEmpresa);

        public void Atualizar(string cnpj, string instituicaoBancaria, TipoContaBancaria tipoConta, string agencia, string numConta, bool contaPrincipal) 
        {
            Cnpj = cnpj;
            InstituicaoBancaria = instituicaoBancaria;
            TipoConta = tipoConta;
            Agencia = agencia;
            NumConta = numConta;
            ContaPrincipal = contaPrincipal;
        }
    }
}
