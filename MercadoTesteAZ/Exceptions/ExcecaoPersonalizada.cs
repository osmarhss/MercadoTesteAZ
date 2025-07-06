namespace MercadoTesteAZ.Exceptions
{
    public class ExcecaoPersonalizada : Exception
    {
        public ExcecaoPersonalizada(string mensagem) : base (mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }
    }
}
