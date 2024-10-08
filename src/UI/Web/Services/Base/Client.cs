namespace Numployable.UI.Web.Services.Base;

public partial interface IClient
{
    HttpClient HttpClient { get; }
}

public partial class Client
{
    public HttpClient HttpClient
    {
        get
        {
            return _httpClient;
        }
    }
}