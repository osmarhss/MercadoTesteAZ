namespace MercadoTesteAZ.Models.SharedValues
{
    public class DadosGeograficos
    {
        public DadosGeograficos(string logradouro, string bairro, string cidade, string uF, string clienteId)
        {
            Id = Guid.NewGuid().ToString("D");
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
            ClienteId = clienteId;
        }

        public string Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string ClienteId { get; private set; }

    }
}
