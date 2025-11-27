using BlazorAuth.Components.Services;
using System.Net.Http;
using Microsoft.Maui.Devices;

namespace BlazorAuth.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        // Choix de l'URL au runtime avec un vrai if/else
        Uri baseAddress;
        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            // Android Emulator : 10.0.2.2 correspond à localhost du PC
            baseAddress = new Uri("http://10.0.2.2:5254/");
        }
        else
        {
            // iOS Simulator, Mac ou Windows : localhost fonctionne
            baseAddress = new Uri("http://localhost:5254/");
        }

        var httpClient = new HttpClient { BaseAddress = baseAddress };
        builder.Services.AddSingleton(httpClient);

        // ApiService avec le HttpClient
        builder.Services.AddSingleton<ApiService>(sp =>
        {
            return new ApiService(sp.GetRequiredService<HttpClient>());
        });

        return builder.Build();
    }
}
