using System.Net.Http.Json;
using BlazorPoC.WebUI.Models;
using BlazorPoC.WebUI.Pages;

namespace BlazorPoC.WebUI.Services;


internal sealed class HttpServices
{
    private readonly HttpClient httpClient;

    public HttpServices(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastData()
    {
        var results = await this.httpClient.GetAsync("/weatherforecast");

        Console.WriteLine(results.Content);
        return await results.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>()?? new List<WeatherForecast>();
    }
}