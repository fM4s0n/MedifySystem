using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services;

/// <summary>
/// 
/// </summary>
public interface IUserService
{
    /// <summary>
    /// 
    /// </summary>
    void LoginUser(User user);

    /// <summary>
    /// 
    /// </summary>
    void LogoutUser();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    User? GetCurrentUser();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    List<User>? GetAllUsers();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    void InsertUser(User user);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    void UpdateUser(User user);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    void DeleteUser(User user);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    User? GetUserById(string id);
}
