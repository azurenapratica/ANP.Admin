using ANPAdmin.Data.Model;

namespace ANPAdmin.Data
{
    public interface IUserRepository
    {
        UserModel ObterPorEmailESenha(string email, string senha);
    }
}
