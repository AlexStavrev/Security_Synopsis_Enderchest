using RestSharp;

namespace Web_Client;
public static class WebClientFactory
{
    public static T GetWebClient<T>(string connectionstring) where T : class
    {
        return typeof(T).Name switch
        {
            "IWebClient" => (new WebClient(new RestClient(connectionstring)) as T)!,
            _ => throw new ArgumentException($"Unknown type {typeof(T).FullName}"),
        };
    }
}
