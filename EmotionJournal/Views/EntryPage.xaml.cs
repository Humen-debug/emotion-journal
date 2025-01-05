#if IOS
using CoreGraphics;
using Foundation;
using Microsoft.Maui.Platform;
using UIKit;
#endif

namespace EmotionJournal.Views;

public partial class EntryPage : ContentPage
{
	public EntryPage(ViewModels.LogViewModel log)
	{
		BindingContext = log;
		InitializeComponent();
#if IOS
		Initialize();
#endif
	}
#if IOS
	double paddingBottom = 0;
	bool showSoftKeyboard;
	NSObject? _keyboardShowObserver;
	NSObject _keyboardHideObserver;


	private void Initialize()
	{
		this.Padding = new(Padding.Left, Padding.Top, Padding.Right, paddingBottom);
		RegisterForKeyboardNotifications();
	}

	// dispose
	~EntryPage()
	{
		UnregisterForKeyboardNotifications();
	}

	// on this iOS platform, adjust the window size when the soft keyboard pops up
	void OnKeyboardShow(object sender, UIKeyboardEventArgs e)
	{
		if (showSoftKeyboard)
		{
			return;
		}

		showSoftKeyboard = true;
		NSValue result = (NSValue)e.Notification.UserInfo.ObjectForKey(new NSString(UIKeyboard.FrameEndUserInfoKey));
		CGSize keyboardSize = result.RectangleFValue.Size;

		paddingBottom = this.Padding.Bottom;
		this.Padding = new Thickness(Padding.Left, Padding.Top, Padding.Right, keyboardSize.Height);
	}

	void OnKeyboardHide(object sender, UIKeyboardEventArgs e)
	{
		if (!showSoftKeyboard)
		{
			return;
		}

		showSoftKeyboard = false;

		this.Padding = new Thickness(Padding.Left, Padding.Top, Padding.Right, paddingBottom);
	}

	void RegisterForKeyboardNotifications()
	{
		_keyboardShowObserver ??= UIKeyboard.Notifications.ObserveWillShow(OnKeyboardShow);
		_keyboardHideObserver ??= UIKeyboard.Notifications.ObserveWillHide(OnKeyboardHide);
	}

	void UnregisterForKeyboardNotifications()
	{
		if (_keyboardShowObserver is not null)
		{
			_keyboardShowObserver.Dispose();
			_keyboardShowObserver = null;
		}

		if (_keyboardHideObserver is not null)
		{
			_keyboardHideObserver.Dispose();
			_keyboardHideObserver = null;
		}
	}
#endif

	public void OnTitleChanged(object sender, TextChangedEventArgs e)
	{
		// title = e.NewTextValue;
	}

	public void OnContentChanged(object sender, TextChangedEventArgs e)
	{
		// content = e.NewTextValue;
	}

	public void OnContentCompleted(object sender, EventArgs e)
	{
		string? text = ((Editor)sender)?.Text;
	}

	/*
	Another solution(?) for page resizing for iOS keyboard
	https://stackoverflow.com/questions/75304124/net-maui-entry-hidden-behind-keyboard-on-ios

	NSValue result = (NSValue)args.Notification.UserInfo.ObjectForKey(new NSString(UIKeyboard.FrameEndUserInfoKey));

	CGSize keyboardSize = result.RectangleFValue.Size;

	private void Entry_Focused(object sender, FocusEventArgs e)
	{
		if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
		{
		   NFloat bottom;
			try
			{
				 UIWindow window = UIApplication.SharedApplication.Delegate.GetWindow();
					bottom = window.SafeAreaInsets.Bottom;
			}
			catch
			{
				 bottom = 0;
			}
			var heightChange = (keyboardSize.Height - bottom);
			layout.TranslateTo(0, originalTranslationY.Value - heightChange, 50);
		}
	}

	private void Entry_Unfocused(object sender, FocusEventArgs e)
	{
		if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
		{
			layout.TranslateTo(0, 0, 50);
		}
	}

	*/
}