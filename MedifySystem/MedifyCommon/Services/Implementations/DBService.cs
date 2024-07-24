using MedifySystem.MedifyCommon.DataAccess;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class DBService(MedifyDatabaseContext medifyDatabaseContext) : IDBService
{
    private readonly MedifyDatabaseContext _dbContext = medifyDatabaseContext;

    //<inheritdoc/>
    public void InsertEntity<T>(T entity) where T : class
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
    }

    //<inheritdoc/>
    public void DeleteEntity<T>(T entity) where T : class
    {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();        
    }

    //<inheritdoc/>
    public IEnumerable<T>? GetEntitiesById<T>(List<string>ids) where T : class
    {
        var entities = new List<T>();

        foreach (var id in ids)
        {
            var entity = GetEntity<T>(id);

            if (entity == null)
                continue;

            entities.Add(entity);
        }

        return entities ?? throw new KeyNotFoundException("Entity not found");
    }

    //<inheritdoc/>
    public T? GetEntity<T>(string id) where T : class
    {        
        var entity = _dbContext.Set<T>().Find(id);

        return entity ?? throw new KeyNotFoundException("Entity not found");       
    }

    //<inheritdoc/>
    public void UpdateEntity<T>(T entity) where T : class
    {
        _dbContext.Set<T>().Update(entity);
        _dbContext.SaveChanges();        
    }

    //<inheritdoc/>
    public void InsertRange<T>(IEnumerable<T> entities) where T : class
    {
        _dbContext.Set<T>().AddRange(entities);
        _dbContext.SaveChanges();
    }

    //<inheritdoc/>
    public List<T>? GetEntitiesByType<T>() where T : class
    {
        List<T>? entities = [.. _dbContext.Set<T>()];
        return entities ?? throw new KeyNotFoundException("Entity not found");
    }
}
