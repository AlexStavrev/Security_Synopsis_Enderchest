using Microsoft.Extensions.DependencyInjection;
using Password_Manager_Desktop_Client.crypto;
using System;
using System.Configuration;
using Web_Client;

namespace Password_Manager_Desktop_Client;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var services = new ServiceCollection();
        ConfigureServices(services);

        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        var desktopClientForm = serviceProvider.GetRequiredService<Form1>();
        Application.Run(desktopClientForm);
        // ApplicationConfiguration.Initialize();
        // Application.Run(new Form1());
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        string webApiUri = ConfigurationManager.ConnectionStrings["webApiUri"].ConnectionString;
        services.AddSingleton((desktopApiClient) => WebClientFactory.GetWebClient<IWebClient>(webApiUri));
        services.AddSingleton<IVaultCrypto>((vault) => new VaultCrypto());
        services.AddScoped<Form1>();
    }
}