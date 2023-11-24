using System;

public class RegistrationManager
{
    private readonly IUserDatabase _userDatabase;

    public RegistrationManager(IUserDatabase userDatabase)
    {
        _userDatabase = userDatabase;
    }

    public bool Register(string username, string password, string confirmPassword)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            throw new ArgumentException("Имя пользователя, пароль и подтверждение пароля не могут быть пустыми.");
        }

        if (password != confirmPassword)
        {
            return false; // Пароли не совпадают
        }

        if (_userDatabase.UserExists(username))
        {
            return false; // Пользователь с таким именем уже существует
        }

        _userDatabase.AddUser(username, password);
        return true;
    }
}
