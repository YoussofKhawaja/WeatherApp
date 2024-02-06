namespace LocalWeatherApp.Interfaces
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
