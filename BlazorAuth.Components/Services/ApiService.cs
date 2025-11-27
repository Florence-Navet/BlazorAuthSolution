using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace BlazorAuth.Components.Services;

public class ApiService
{
    public readonly HttpClient _http;

    public ApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> CheckApiAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/photo");
            if (response.IsSuccessStatusCode)
                return "Appel API réussi";

            return $"Pb api : {response.StatusCode}";
        }
        catch (Exception ex)
        {

            return $"Erreur : {ex.Message}";
        }
    }

}
