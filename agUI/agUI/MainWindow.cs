using System;
using Gtk;

using System.Diagnostics;

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
	
	protected void OnEntry3Changed (object sender, EventArgs e)
	{
		Gtk.Entry entry = sender as Entry;
		Preprocess (entry.Text);
	}

	protected void Preprocess(string searchTerms)
	{
		cbIgnoreCase.Active = searchTerms.Contains ("-i");

	}

	protected void OnEntry3Activated (object sender, EventArgs e)
	{
		RefreshSearch();
	}

	protected void RefreshSearch()
	{
		Search (entry3.Text);
	}

	protected void Search(string searchTerms)
	{
		Process P = new Process();                        
		P.StartInfo.FileName = "/usr/bin/ag";
		P.StartInfo.WorkingDirectory = "/home/koonkiat/Documents";
		P.StartInfo.UseShellExecute = false;
		P.StartInfo.RedirectStandardOutput = true;

		string arg = searchTerms;
			
		if (fileRegex.Text.Trim ().Length != 0) {
			arg = String.Format("-G {0} {1}", fileRegex.Text.Trim (), searchTerms);
		}

		P.StartInfo.Arguments = arg;
		P.Start();

		string s = P.StandardOutput.ReadToEnd();
		Console.WriteLine (s);

		textview1.Buffer.Text = s;
	}

	protected void OnFileRegexActivated (object sender, EventArgs e)
	{
		RefreshSearch();
	}
}
