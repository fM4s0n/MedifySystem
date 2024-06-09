using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services.Implementations;

namespace MedifySystem.MedifyCommon.Services;

/// <summary>
/// 
/// </summary>
public interface IUserService
{
    // Login and Logout event handlers
    event UserService.LogoutEventHandler LogOutEvent;
    event UserService.LoginEventHandler LogInEvent;
    event UserService.ResetPasswordHandler ResetPasswordEvent;

    /// <summary>
    /// Logs in the user
    /// </summary>
    void LogInUser(User user, bool requiresRest = false);

    /// <summary>
    /// logs out the user
    /// </summary>
    void LogOutUser();

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

    /// <summary>
    /// Gets all active patients for a user
    /// </summary>
    /// <param name="userId">user id of the HospitalOfficial</param>
    /// <returns>List of Patient if found any, null if not</returns>
    List<Patient>? GetAllActivePatientsForUser(string userId);

    /// <summary>
    /// Gets all upcoming appointments for a user
    /// </summary>
    /// <param name="user">User who is conducting the appointment</param>
    /// <returns>List of appointment object or null if non found or not a doctor or nurse</returns>
    List<Appointment>? GetAllUpcomingAppointmentsForUser(User user, bool includedCancelled);
}
