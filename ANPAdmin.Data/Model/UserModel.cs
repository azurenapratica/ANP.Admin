using System.ComponentModel.DataAnnotations;

namespace ANPAdmin.Data.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
