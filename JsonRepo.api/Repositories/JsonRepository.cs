namespace JsonRepo.api.Repositories;

public class JsonRepository<T> : IRepository<T> where T : class
{
    private readonly string _filePath;
    private List<T> _data;

    public JsonRepository()
    {
        this._filePath = $"Data/{typeof(T).Name.ToLower()}.json";
        _data = LoadDataAsync().Result;        
    }

    private async Task<List<T>> LoadDataAsync()
    {
        if(!File.Exists(_filePath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
            await File.WriteAllTextAsync(_filePath, "[]");
        }

        var jsonData = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
    }

    private async Task SaveDataAsync()
    {
        var jsonData = JsonSerializer.Serialize(_data, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            , WriteIndented = true
        });
        await File.WriteAllTextAsync(_filePath, jsonData);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await Task.FromResult(_data);

    public async Task<T?> GetByIdAsync(long id)
    {
        var propertyInfo = typeof(T).GetProperty("Id");
        if (propertyInfo == null) return null;

        return await Task.FromResult(_data.FirstOrDefault(item => (long)propertyInfo.GetValue(item)! == id));
    }

    public async Task CreateAsync(T entity)
    {
        var propertyInfo = typeof(T).GetProperty("Id");
        if (propertyInfo == null) return;

        var maxId = _data.Any() ? _data.Max(item => (long)propertyInfo.GetValue(item)!) : 0;
        propertyInfo.SetValue(entity, maxId + 1);

        _data.Add(entity);
        await SaveDataAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        var propertyInfo = typeof(T).GetProperty("Id");
        if (propertyInfo == null) return;

        var id = (long)propertyInfo.GetValue(entity)!;
        var existingEntity = await GetByIdAsync(id);

        if (existingEntity == null) return;

        _data.Remove(existingEntity);
        _data.Add(entity);

        await SaveDataAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var existingEntity = await GetByIdAsync(id);
        if (existingEntity == null) return;

        _data.Remove(existingEntity);
        await SaveDataAsync();
    }
}
