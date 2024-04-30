using Microsoft.Extensions.Logging;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSentry(options => {
					// The DSN is the only required setting.
					options.Dsn = "https://3cb93465fbbb4956d5b89b40f67a8b9b@o982579.ingest.us.sentry.io/4507176872312832";

					// Use debug mode if you want to see what the SDK is doing.
					// Debug messages are written to stdout with Console.Writeline,
					// and are viewable in your IDE's debug console or with 'adb logcat', etc.
					// This option is not recommended when deploying your application.
					options.Debug = true;
					options.DiagnosticLevel = SentryLevel.Debug;

					// Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
					// We recommend adjusting this value in production.
					options.TracesSampleRate = 1.0;

					// Sample rate for profiling, applied on top of othe TracesSampleRate,
					// e.g. 0.2 means we want to profile 20 % of the captured transactions.
					// We recommend adjusting this value in production.
					options.ProfilesSampleRate = 1.0;

					// Other Sentry options can be set here.
			})
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
}
