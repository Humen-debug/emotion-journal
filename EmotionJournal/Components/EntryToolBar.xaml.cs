namespace EmotionJournal.Components;

public partial class EntryToolBar : ContentView
{
	public EntryToolBar()
	{
		InitializeComponent();
		this.BindingContext = this;
	}

	private bool _showToolBar = true;

	public bool ShowToolBar {
		get => _showToolBar;
	}

	public void OnMarkdownBtnClicked(object sender, EventArgs e)
	{
		if(!_showToolBar) {
			_showToolBar = true;
		}
	}

	public void OnImageBtnClicked(object sender, EventArgs e)
	{
		if(!_showToolBar) {
			_showToolBar = true;
		}
	}

	public void OnCameraBtnClicked(object sender, EventArgs e)
	{
		if(!_showToolBar) {
			_showToolBar = true;
		}
	}

	public void OnLocationBtnClicked(object sender, EventArgs e)
	{
		if(!_showToolBar) {
			_showToolBar = true;
		}
	}

	public void OnRecordBtnClicked(object sender, EventArgs e)
	{
		if(!_showToolBar) {
			_showToolBar = true;
		}
	}

	public void OnFeelingBtnClicked(object sender, EventArgs e)
	{
		if(_showToolBar) {
			_showToolBar = false;
			// Console.WriteLine("Try hide showToolBar");
		}
	}
}