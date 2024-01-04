using Godot;
using System;

public partial class TextBox : Control
{
	[Export] private RichTextLabel label;
	
	public void SetText(string s)
	{
		label.Text = s;
	}
}
