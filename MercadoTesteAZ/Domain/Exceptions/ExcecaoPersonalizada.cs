namespace MercadoTesteAZ.Domain.Exceptions
{
    public class ExcecaoPersonalizada : Exception
    {
        public ExcecaoPersonalizada(string mensagem) : base (mensagem)
        {
            Mensagem = mensagem;
        }

        public ExcecaoPersonalizada(string mensagem, int statusCode = StatusCodes.Status400BadRequest) : base(mensagem)
        {
            Mensagem = mensagem;
            StatusCode = statusCode;
        }
        public int StatusCode { get; }
        public string Mensagem { get; }
    }
}
