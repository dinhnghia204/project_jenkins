using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace UC.SOFTIP.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("UCSOFTIP_API");
            var response = await client.GetAsync("/api/weatherforecast");
            
            if (response.IsSuccessStatusCode)
            {
                var weatherData = await response.Content.ReadAsStringAsync();
                var weatherList = JsonSerializer.Deserialize<List<WeatherForecast>>(weatherData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                
                ViewBag.WeatherList = weatherList;
                ViewBag.ApiStatus = "success";
            }
            else
            {
                ViewBag.ApiStatus = $"error: API returned status {response.StatusCode}";
            }
        }
        catch (Exception ex)
        {
            ViewBag.ApiStatus = $"error: {ex.Message}";
        }
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF { get; set; }
    public string? Summary { get; set; }
}

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
