using Esri.ArcGISRuntime;
using Microsoft.Extensions.Logging;
using Esri.ArcGISRuntime.Toolkit.Maui;
using Esri.ArcGISRuntime.Maui;
using Esri.ArcGISRuntime.UI;

namespace DisplayAMaps
{
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
                })
                
                .UseArcGISToolkit();

            builder.UseArcGISRuntime(config => config.UseApiKey("AAPKa312290326f84f8587f1f6bbcd52454df1Q4kf8GTbET2nnyI6_UwCVzqh-9t8kLEIqLVguIPl1p0flueT9U3grLB0cwwpIY"));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
