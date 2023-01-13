using Microsoft.JSInterop;

namespace CSP.MainApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
