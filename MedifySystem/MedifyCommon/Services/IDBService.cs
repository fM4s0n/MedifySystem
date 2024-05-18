namespace MedifySystem.MedifyCommon.Services;

/// <summary>
/// Database Service 
/// This is simulating calling a Web API 
/// Instead of calling DbContext, this would call the API, 
/// however the Interface would remain the same
/// </summary>
public interface IDBService
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    void InsertEntity<T>(T entity) where T : class;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entities"></param>
    void InsertRange<T>(IEnumerable<T> entities) where T : class;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    void UpdateEntity<T>(T entity) where T : class;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    void DeleteEntity<T>(T entity) where T : class;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    T? GetEntity<T>(string id) where T : class;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ids"></param>
    /// <returns></returns>
    IEnumerable<T>? GetEntitiesById<T>(List<string> ids) where T : class;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    List<T>? GetEntitiesByType<T>() where T : class;
}
