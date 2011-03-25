﻿using System.Diagnostics;
using System.Windows.Controls;

namespace ClojureExtension.Repl
{
	public class ReplWriter
	{
		private readonly Process _process;
		private readonly TextBox _interactiveTextBox;

		public ReplWriter(Process process, TextBox interactiveTextBox)
		{
			_process = process;
			_interactiveTextBox = interactiveTextBox;
		}

		public void WriteBehindTheSceneExpressionToRepl(string expression)
		{
			WriteExpressionToRepl(expression);
			WriteToInteractive("\r\n");
		}

		public void WriteExpressionToRepl(string expression)
		{
			_process.StandardInput.Write(expression + "\r\n");
		}

		public void WriteToInteractive(string s)
		{
			_interactiveTextBox.AppendText(s);
			_interactiveTextBox.ScrollToEnd();
		}
	}
}