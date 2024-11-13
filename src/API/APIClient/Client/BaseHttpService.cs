namespace Numployable.APIClient.Client;

using System.Net.Http.Headers;

using Numployable.APIClient.Contracts;

public class BaseHttpService(IClient client, ILocalStorageService localStorage)
{
    protected readonly ILocalStorageService _localStorage = localStorage;

    protected IClient _client = client;

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
    {
        if (exception.StatusCode == 400)
        {
            return new Response<Guid>() {
                Message = "Validation errors has occurred.",
                ValidationErrors = exception.Response,
                Success = false
            };
        }
        else if (exception.StatusCode == 404)
        {
            return new Response<Guid>() {
                Message = "The requested item could not be found.",
                Success = false
            };
        }
        else
        {
            return new Response<Guid>() {
                Message = "Something went wrong, please try again.",
                Success = false
            };
        }
    }

    protected void AddBearerToken()
    {
        if (_localStorage.Exists("token"))
        {
            _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));
        }    
    }
}