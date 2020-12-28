namespace ANPAdmin.UI.Model
{
    public class UserModel
    {
        public UserModel(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
