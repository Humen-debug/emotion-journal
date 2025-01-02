using DotNet.Meteor.HotReload.Plugin;
using Microsoft.Extensions.Logging;

namespace EmotionJournal;

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
				fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIconsRegular");
			});

#if DEBUG
		builder.Logging.AddDebug();
		builder.EnableHotReload();
#endif

		return builder.Build();
	}
}
