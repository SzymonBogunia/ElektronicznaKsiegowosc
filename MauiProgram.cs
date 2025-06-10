using Microsoft.EntityFrameworkCore;
using Ksiegowosc.Services;
using Ksiegowosc.View;
using Ksiegowosc.ViewModel;

namespace Ksiegowosc;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Rejestracja DbContext
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "ksiegowosc.db")}"));

        // Rejestracja DatabaseInitializer
        builder.Services.AddSingleton<DatabaseInitializer>();

        // Rejestracja ViewModeli i View
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<IssuedInvoicesViewModel>();
        builder.Services.AddTransient<IssuedInvoicesPage>();
        builder.Services.AddTransient<AppShell>();
        builder.Services.AddTransient<ReceivedInvoicesViewModel>();
        builder.Services.AddTransient<ReceivedInvoicesPage>();
        builder.Services.AddTransient<ContractorsViewModel>();
        builder.Services.AddTransient<ContractorsPage>();

        return builder.Build();
    }
}

