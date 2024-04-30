namespace MauiApp1;
using Sentry;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnErrorButtonClick(object sender, EventArgs e)
{
    throw new Exception("This is a test error thrown by clicking the button.");
}

private void TriggerUnhandledError(object sender, EventArgs e)
{
    throw new InvalidOperationException("Unhandled exception triggered by button click.");
}

private void LogMessage(object sender, EventArgs e)
{
		SentrySdk.CaptureMessage("Something went wrong");
		
    Console.WriteLine("This is a test log message from the button click.");
}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

