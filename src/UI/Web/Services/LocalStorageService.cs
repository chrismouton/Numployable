using Hanssens.Net;
using Numployable.APIClient.Contracts;

namespace Numployable.UI.Web.Services;

public class LocalStorageService : ILocalStorageService
{
  private readonly LocalStorage _storage;

  public LocalStorageService()
  {
    LocalStorageConfiguration? config = new()
    {
      AutoLoad = true,
      AutoSave = true,
      Filename = "NUMPLOYABLE"
    };

    _storage = new LocalStorage(config);
  }

  public void ClearStorage(List<string> keys)
  {
    foreach (string? key in keys)
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
