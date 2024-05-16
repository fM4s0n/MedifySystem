namespace MedifySystem.MedifyCommon.Services;

public interface IDBService
{
    void InsertEntity<T>(T entity) where T : class;
    void UpdateEntity<T>(T entity) where T : class;
    void DeleteEntity<T>(T entity) where T : class;
    T GetEntity<T>(int id) where T : class;
    IEnumerable<T> GetEntities<T>() where T : class;
}
