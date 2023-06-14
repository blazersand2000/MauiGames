using Memorize.ViewModel;

namespace Memorize;

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

      builder.Services.AddSingleton<MemorizePage>();
      builder.Services.AddSingleton<MemorizeViewModel>();

      return builder.Build();
	}
}
