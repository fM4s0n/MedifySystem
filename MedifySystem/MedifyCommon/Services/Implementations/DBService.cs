using MedifySystem.MedifyCommon.DataAccess;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class DBService(MedifyDatabaseContext medifyDatabaseContext) : IDBService
{
    private readonly MedifyDatabaseContext _dbContext = medifyDatabaseContext;

    //<inheritdoc/>
    public void InsertEntity<T>(T entity) where T : class
    {
        try
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //<inheritdoc/>
    public void DeleteEntity<T>(T entity) where T : class
    {
        try
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        
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
        try
        {
            var entity = _dbContext.Set<T>().Find(id);

            return entity ?? throw new KeyNotFoundException("Entity not found");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    //<inheritdoc/>
    public void UpdateEntity<T>(T entity) where T : class
    {
        try
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //<inheritdoc/>
    public void InsertRange<T>(IEnumerable<T> entities) where T : class
    {
        try
        {
            _dbContext.Set<T>().AddRange(entities);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //<inheritdoc/>
    public List<T>? GetEntitiesByType<T>() where T : class
    {
        try
        {
            List<T>? entities = [.. _dbContext.Set<T>()];

            return entities ?? throw new KeyNotFoundException("Entity not found");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
}
