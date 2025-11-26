namespace Numployable.APIClient.Client;

public partial interface IClient
{
    HttpClient HttpClient { get; }
}

public partial class Client : IClient
{
    public HttpClient HttpClient { get; }
}