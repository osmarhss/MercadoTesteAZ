namespace MercadoTesteAZ.Models.SharedValues
{
    public class DadosContato
    {
        public DadosContato(string email, string telefone)
        {
            Email = email;
            Telefone = telefone;
        }

        public string Email { get; set; }
        public string? Telefone { get; set; }
    }
}
