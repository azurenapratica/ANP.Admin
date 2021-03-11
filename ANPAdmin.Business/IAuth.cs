namespace ANPAdmin.Business
{
    public interface IAuth
    {
        AuthModel Login(string email, string password);
    }
}
