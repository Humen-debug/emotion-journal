using EmotionJournal.Views;

namespace EmotionJournal;

public partial class App : Application
{

	public static ViewModels.LogListViewModel? LogsListViewModel { get; private set; }
	public App()
	{
		InitializeComponent();
        NavigationPage MainPage = new(new EntriesListPage());
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = new Window(new AppShell());

		LogsListViewModel = new();
		LogsListViewModel.RefreshLogs().ContinueWith((x) => { });

		return window;
	}
}