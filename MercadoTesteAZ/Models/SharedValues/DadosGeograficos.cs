namespace MarketAzCorp.Models.SharedValues
{
    public class DadosGeograficos
    {
        public DadosGeograficos(string logradouro, string bairro, string cidade, string uF)
        {
            Id = Guid.NewGuid().ToString("D");
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
        }

        public string Id { get; private set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}
