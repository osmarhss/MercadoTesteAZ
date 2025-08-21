using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;

namespace MercadoTesteAZ.Domain.Entities.Empresas
{
    public class Transportadora : IEntity
    {
        protected Transportadora() { }

        private Transportadora(string id, string nome, string cnpj, bool ativo, int numDeEntregas, double notaAvaliacao, ContaBancaria conta) 
        {
            Id = id;
            Nome = nome;
            Cnpj = cnpj;
            Ativo = ativo;
            NumDeEntregas = numDeEntregas;
            NotaAvaliacao = notaAvaliacao;
            ContaBancaria = conta;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public bool Ativo { get; private set; }
        public int NumDeEntregas { get; private set; }
        public double NotaAvaliacao { get; private set; }
        public ContaBancaria ContaBancaria { get; private set; }

        public static Transportadora Adicionar(string nome, string cnpj, bool ativo, ContaBancaria conta)
            => new Transportadora(Guid.NewGuid().ToString("D"), nome, cnpj, ativo, 0, 0, conta);

        public void Atualizar(string nome, bool ativo) 
        {
            Nome = nome;
            Ativo = ativo;
        }
    }
}
