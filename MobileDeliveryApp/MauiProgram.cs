﻿using CommunityToolkit.Maui;
using MobileDeliveryApp.Services.Contracts.Authentication;
using MobileDeliveryApp.Services.Contracts.ScanLoad;
using MobileDeliveryApp.Services.Contracts.WayBillInfo;
using MobileDeliveryApp.Services.Implementation.Authentication;
using MobileDeliveryApp.Services.Implementation.ScanLoad;
using MobileDeliveryApp.Services.Implementation.WaybillInfo;
using MobileDeliveryApp.Services.Mappings;
using MobileDeliveryApp.ViewModels.Authentication;
using MobileDeliveryApp.ViewModels.ScanLoad;
using MobileDeliveryApp.Views.Authentication;
using MobileDeliveryApp.Views.ScanLoad;
using MobileDeliveryApp.Views.WaybillInfomation;

namespace MobileDeliveryApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


        builder.Services.AddAutoMapper(typeof(MapperConfig));
        builder.Services.AddSingleton<LandingPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<ScanLoadPage>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<ScanLoadViewModel>();
        builder.Services.AddSingleton<WayBillInfoPage>();
        builder.Services.AddSingleton<LandingPageViewModel>();
        builder.Services.AddTransient<IAuthService, AuthService>();
        builder.Services.AddTransient<IScanLoadInterface, ScanLoadInterface>();
        builder.Services.AddTransient<IWaybillInformationService, WaybillInformationService>();

        return builder.Build();
    }
}