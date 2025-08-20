public interface IMonitoramentoService
{
    Task<bool>
        VerificarSiteAsync(string url);
}

public class MonitoramentoService : IMonitoramentoService
{
    private readonly HttpClient
        _httpCliente;

    public
    MonitoramentoService(HttpClient httpClient)
    {
        _httpCliente = httpClient;
        _httpCliente.Timeout = TimeSpan.FromSeconds(5);

        _httpCliente.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 "+"(KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");
    }
       
    public async Task<bool>VerificarSiteAsync(string url)
    {
        try
        {
            if (!url.StartsWith("http"))
                url = "https://" + url;
            var response = await _httpCliente.GetAsync(url);

            return
            ((int)response.StatusCode >= 200 &&
            (int)response.StatusCode < 400);
        }
        catch
        {
            return false;
        }
    }



}