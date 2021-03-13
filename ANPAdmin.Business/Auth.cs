using ANPAdmin.Data;

namespace ANPAdmin.Business
{
    public class Auth : IAuth
    {
        private IUserRepository _userRepository;

        public Auth(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthModel Login(string email, string senha)
        {
            var usuario = _userRepository.ObterPorEmailESenha(email, senha);

            //if (usuario == null)
            // Simulação de falha
            if (usuario == null || !usuario.Ativo)
                return null;

            return new AuthModel(usuario.Id, usuario.Nome, usuario.Email);
        }
    }
}
