using Godot;
using System;

public partial class TextDocFileElement : LinkButton
{
	[Export] private PackedScene fileScene;

	public void Pressed()
	{
		if (fileScene == null) return;
		
		((FileSystemManager) Owner).OpenDocument(fileScene.Instantiate<Control>());
	}
}
