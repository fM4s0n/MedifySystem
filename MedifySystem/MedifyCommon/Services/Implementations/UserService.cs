using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class UserService(IDBService? dbService = null) : IUserService
{
    private readonly IDBService? _dbService = dbService ?? Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;

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
    public void InsertUser(User user)
    {
        _dbService?.InsertEntity(user);
    }

    //<inheritdoc/>
    public void LoginUser(User user)
    {
        if (user != null)
            _currentUser = user;
    }

    //<inheritdoc/>
    public void LogoutUser()
    {
        _currentUser = null;
    }

    //<inheritdoc/>
    public void UpdateUser(User user)
    {
        _dbService?.UpdateEntity(user);
    }
}
