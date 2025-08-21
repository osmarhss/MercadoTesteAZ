using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Enums;

namespace MercadoTesteAZ.Domain.Entities.Usuário
{
    public class Usuario : IEntity
    {
        protected Usuario() { }
        private Usuario(string id, string email, TipoUsuario tipoUsuario, DateTime dataCadastro) 
        {
            Id = id;
            Email = email;
            TipoUsuario = tipoUsuario;
            DataCadastro = dataCadastro;
        }
        public string Id { get; private set; }
        public string Email { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public static Usuario Adicionar(string email, int tipoUsuario) 
            => new Usuario(Guid.NewGuid().ToString("D"), email, (TipoUsuario)tipoUsuario, DateTime.Now);

        public void Atualizar(string email) 
        {
            Email = email;
        }
        
    }
}
