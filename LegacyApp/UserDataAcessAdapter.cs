namespace LegacyApp
{
    public class UserDataAcessAdapter : IUserDataAccess
    {
        public void AddUser(User user)
        {
            UserDataAccess.AddUser(user);
        }
    }

}
