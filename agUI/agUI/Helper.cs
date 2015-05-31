using System;
using System.Diagnostics;

namespace agUI
{
	public struct SearchParam
	{
		public string searchTerms;
		public string fileRegexText;
	}

	public class Helper
	{
		public Helper ()
		{
		}

		protected void Preprocess(string searchTerms)
		{
			//cbIgnoreCase.Active = searchTerms.Contains ("-i");

		}

		static public string RefreshSearch(SearchParam param)
		{
			return Search (param);
		}

		static protected string Search(SearchParam param)
		{
			Process P = new Process();                        
			P.StartInfo.FileName = "/usr/bin/ag";
			P.StartInfo.WorkingDirectory = "/home/koonkiat/Documents";
			P.StartInfo.UseShellExecute = false;
			P.StartInfo.RedirectStandardOutput = true;

			string arg = param.searchTerms;

			if (param.fileRegexText.Length != 0) {
				arg = String.Format("-G {0} {1}", param.fileRegexText, param.searchTerms);
			}

			P.StartInfo.Arguments = arg;
			P.Start();

			string s = P.StandardOutput.ReadToEnd();
			Console.WriteLine (s);

			return s;
		}
	}
}

