using Godot;
using System;

public partial class FolderFileElement : LinkButton
{
	[Export] private Control pagesRoot;
	[Export] private Control targetPage;
	
	public void OnPressed()
	{
		foreach (Control child in pagesRoot.GetChildren())
		{
			child.Visible = false;
		}

		targetPage.Visible = true;
	}
}
