using System;
using Gtk;

using System.Diagnostics;
using agUI;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected void RefreshSearch()
	{
		SearchParam s = new SearchParam ();
		s.fileRegexText = fileRegex.Text.Trim ();
		s.searchTerms = entry3.Text.Trim ();

		textview1.Buffer.Text = Helper.RefreshSearch (s);
	}

	protected void OnEntry3Activated (object sender, EventArgs e)
	{
		RefreshSearch();
	}

	protected void OnFileRegexActivated (object sender, EventArgs e)
	{
		RefreshSearch();
	}
}
