namespace EmotionJournal;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        NavigationPage MainPage = new(new MainPage());
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}