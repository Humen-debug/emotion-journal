namespace EmotionJournal;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("EntryPage", typeof(EntryPage));
	}
}
