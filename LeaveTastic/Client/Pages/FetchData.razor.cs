using LeaveTastic.Common.Services;
using LeaveTastic.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace LeaveTastic.Client.Pages
{
    public partial class FetchData : ComponentBase
    {
        [Inject]
        private HelperService helperService { get; set; } = default!;

        private IEnumerable<WeatherForecast>? forecasts;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                forecasts = await helperService.HttpService.Get<List<WeatherForecast>>("WeatherForecast");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
