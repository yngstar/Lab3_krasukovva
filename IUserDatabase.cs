public interface IUserDatabase
{
    bool UserExists(string username);
    void AddUser(string username, string password);
}
