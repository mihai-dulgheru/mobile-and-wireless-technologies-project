﻿using Microsoft.Extensions.Logging;

namespace Project;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("GothamRound-Bold.otf", "GothamRoundBold");
                fonts.AddFont("GothamRound-Light.otf", "GothamRoundLight");
                fonts.AddFont("GothamRound-Medium.otf", "GothamRoundMedium");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<Data.IProductDatabase, Data.ProductDatabase>();
        builder.Services.AddSingleton<Services.IRestService, Services.RestService>();

        return builder.Build();
    }
}
