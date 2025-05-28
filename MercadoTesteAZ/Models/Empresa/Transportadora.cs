namespace MercadoTesteAZ.Models.Empresa
{
    public class Transportadora
    {
        public Transportadora(string id, string nome, string cnpj, bool ativo)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
            Nome = nome;
            Cnpj = cnpj;
            Ativo = ativo;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
    }
}
