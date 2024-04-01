using DevExpress.Maui;

using Services.Interfaces;
using ViewModels.Base;

using MauiPdfViewer.ViewModels;

using Microsoft.Extensions.Logging;

using SkiaSharp.Views.Maui.Controls.Hosting;
using Services;

namespace MauiPdfViewer;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            
            .UseDevExpress() // required for pdf-viewer
            .UseSkiaSharp()  // required for pdf-viewer

            .RegisterServices()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        RegisterUtilityServices(builder);
        RegisterViewModelsAndPages(builder);

        return builder;
    }

    private static void RegisterUtilityServices(MauiAppBuilder builder)
    {
        // Singleton services
        builder.Services.AddSingleton<IPluggablePageHandler, PluggablePageHandler>();
    }

    private static void RegisterViewModelsAndPages(MauiAppBuilder builder)
    {
        builder.RegisterPageAndViewModel<MainPage, MainViewModel>();
    }

    private static void RegisterPageAndViewModel<TPage, TViewModel>(this MauiAppBuilder builder)
                                                                            where TViewModel : BaseViewModel where TPage : Page
    {
        builder.Services.AddTransient<TPage>();
        builder.Services.AddTransient<TViewModel>();
    }
}
