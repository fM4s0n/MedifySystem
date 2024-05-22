using MedifySystem.MedifyCommon.Helpers;
using MedifySystem.MedifyCommon.Models;
using Microsoft.AspNetCore.Identity;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class UserService(IDBService? dbService = null) : IUserService
{
    private readonly IDBService? _dbService = dbService ?? Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;

    // Login and Logout event handlers
    public delegate void LogoutEventHandler(object sender, EventArgs e);
    public delegate void LoginEventHandler(object sender, EventArgs e);

    public event LogoutEventHandler? LogOutEvent;
    public event LoginEventHandler? LogInEvent;

    private User? _currentUser = null;

    //<inheritdoc/>
    public User? GetCurrentUser()
    {
        return _currentUser;
    }

    //<inheritdoc/>
    public void DeleteUser(User user)
    {
        _dbService!.DeleteEntity(user);
    }

    //<inheritdoc/>
    public List<User>? GetAllUsers()
    {
        return _dbService!.GetEntitiesByType<User>()!;
    }

    //<inheritdoc/>
    public User? GetUserById(string id)
    {
        return _dbService?.GetEntity<User>(id);
    }

    //<inheritdoc/>
    public void InsertUser(User user) => _dbService?.InsertEntity(user);

    //<inheritdoc/>
    public void LoginUser(User user)
    {
        if (user != null)
            _currentUser = user;

        OnLogin();
    }

    //<inheritdoc/>
    public void LogoutUser()
    {
        _currentUser = null;
        OnLogout();
    }
 
    //<inheritdoc/>
    public void UpdateUser(User user)
    {
        _dbService?.UpdateEntity(user);
    }

    //<inheritdoc/>
    public bool AuthenticateUser(string email, string password)
    {
        List<User>? users = GetAllUsers();
        if (users == null)
            return false;

        foreach (User user in users)
        {
            if (user.Email == email)
            {
                bool result = PasswordHelper.VerifyPassword(user, password) != PasswordVerificationResult.Failed;
                
                if (result)
                    LoginUser(user);

                return result;
            }
        }

        return false;
    }

    /// <summary>
    /// Login Event
    /// </summary>
    public void OnLogin() => LogInEvent?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// Logout Event
    /// </summary>
    public void OnLogout() => LogOutEvent?.Invoke(this, EventArgs.Empty);

}
