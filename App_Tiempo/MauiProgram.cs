using SkiaSharp.Views.Maui.Controls.Hosting;

namespace App_Tiempo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureEssentials(essentials =>
			{
				essentials.UseMapServiceToken("Q8n5OPfpHNvBPmuFn2nB~l0kyB2KBWKhLqMa6bhq8QA~ArNBHVgVlxqNo4cuaH96h2XdAkIb-IjEjldZUoZ7j_bVPSz0if33e1bnhgDbo9Ij");
			});

		return builder.Build();
	}
}
