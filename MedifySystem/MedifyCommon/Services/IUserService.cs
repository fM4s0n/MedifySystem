using MedifySystem.MedifyCommon.Models;
using static MedifySystem.MedifyCommon.Services.Implementations.UserService;

namespace MedifySystem.MedifyCommon.Services;

/// <summary>
/// 
/// </summary>
public interface IUserService
{
    // Login and Logout event handlers
    public event LogoutEventHandler? LogOutEvent;
    public event LoginEventHandler? LogInEvent;

    /// <summary>
    /// Logs in the user
    /// </summary>
    void LoginUser(User user);

    /// <summary>
    /// logs out the user
    /// </summary>
    void LogoutUser();

    /// <summary>
    /// get the current user
    /// </summary>
    /// <returns>User object of the current user if set, null otherwise</returns>
    User? GetCurrentUser();

    /// <summary>
    /// gets every user in the database
    /// </summary>
    /// <returns>List/returns>
    List<User>? GetAllUsers();

    /// <summary>
    /// Inserts a user into the database
    /// </summary>
    /// <param name="user"></param>
    void InsertUser(User user);

    /// <summary>
    /// updates a current user in the database
    /// </summary>
    /// <param name="user">User being updated</param>
    void UpdateUser(User user);

    /// <summary>
    /// deletes a user from the database
    /// </summary>
    /// <param name="user">User to be deleted</param>
    void DeleteUser(User user);

    /// <summary>
    /// gets a user by their id
    /// </summary>
    /// <param name="id">id of the user</param>
    /// <returns>User object of the found user if found, null if not</returns>
    User? GetUserById(string id);

    /// <summary>
    /// Authenticates a user by their email and password
    /// </summary>
    /// <param name="email">email provided by the user</param>
    /// <param name="password">provided password</param>
    /// <returns></returns>
    bool AuthenticateUser(string email, string password);

    /// <summary>
    /// Login event
    /// </summary>
    void OnLogin();

    /// <summary>
    /// logout event
    /// </summary>
    void OnLogout();
}
