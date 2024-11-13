namespace Numployable.UI.Web.Services;

using Hanssens.Net;

using Numployable.APIClient.Contracts;

public class LocalStorageService : ILocalStorageService
{
    private LocalStorage _storage;

    public LocalStorageService()
    {
        var config = new LocalStorageConfiguration()
        {
            AutoLoad = true,
            AutoSave = true,
            Filename = "NUMPLOYABLE"
        };

        _storage = new LocalStorage(config);
    }

    public void ClearStorage(List<string> keys)
    {
        foreach (string key in keys)
            _storage.Remove(key);
    }

    public bool Exists(string key)
    {
        return _storage.Exists(key);
    }

    public T GetStorageValue<T>(string key)
    {
        return _storage.Get<T>(key);
    }

    public void SetStorageValue<T>(string key, T value)
    {
        _storage.Store<T>(key, value);
        _storage.Persist();
    }
}
