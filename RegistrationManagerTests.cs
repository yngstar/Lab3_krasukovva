using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RegistrationManagerTests
{
    private const string connectionString = "Server=your_server;Database=your_database;Uid=your_username;Pwd=your_password;";

    [TestMethod]
    public void Register_ValidUser_ReturnsTrue()
    {
        IUserDatabase userDatabase = new UserDatabase(connectionString);
        RegistrationManager registrationManager = new RegistrationManager(userDatabase);

        bool result = registrationManager.Register("testuser", "password", "password");

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Register_PasswordsDoNotMatch_ReturnsFalse()
    {
        IUserDatabase userDatabase = new UserDatabase(connectionString);
        RegistrationManager registrationManager = new RegistrationManager(userDatabase);

        bool result = registrationManager.Register("testuser", "password1", "password2");

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Register_UsernameAlreadyExists_ReturnsFalse()
    {
        IUserDatabase userDatabase = new UserDatabase(connectionString);
        userDatabase.AddUser("existinguser", "password");
        RegistrationManager registrationManager = new RegistrationManager(userDatabase);

        bool result = registrationManager.Register("existinguser", "newpassword", "newpassword");

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Register_EmptyValues_ReturnsFalse()
    {
        IUserDatabase userDatabase = new UserDatabase(connectionString);
        RegistrationManager registrationManager = new RegistrationManager(userDatabase);

        bool result = registrationManager.Register("", "", "");

        Assert.IsFalse(result);
    }
}
