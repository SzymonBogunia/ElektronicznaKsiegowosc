using Ksiegowosc.Services;
using Ksiegowosc.View;

namespace Ksiegowosc;


public partial class App : Application
{
    public App(DatabaseInitializer databaseInitializer, AppShell appShell)
    {
        try
        {
            InitializeComponent();
            databaseInitializer.InitializeDatabase();
            MainPage = appShell;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Błąd inicjalizacji w App.xaml.cs: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
            throw;
        }
    }
}
