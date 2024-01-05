using Godot;
using System;

public partial class FolderFileElement : LinkButton
{
	[Export] private Control targetPage;

	public void OnPressed()
	{
		if (targetPage == null) return;
		
		((FileSystemManager) Owner).UpdateNav(targetPage);
	}
}
