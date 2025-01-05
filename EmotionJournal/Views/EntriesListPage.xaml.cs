

namespace EmotionJournal.Views;

public partial class EntriesListPage : ContentPage
{

	public EntriesListPage()
	{
		InitializeComponent();
	}

	private async void OnAddEntryClicked(object sender, EventArgs e)
	{
		// await Shell.Current.GoToAsync("EntryPage");
		ViewModels.LogViewModel log = new ();
		await Navigation.PushAsync(new EntryPage(log));
	}
}