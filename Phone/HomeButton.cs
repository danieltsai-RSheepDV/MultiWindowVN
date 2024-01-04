using Godot;
using System;

public partial class HomeButton : TextureButton
{
	[Export] private Control screensRoot;
	[Export] private Control homeScreen;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnPressed()
	{
		foreach (Control child in screensRoot.GetChildren())
		{
			child.Visible = false;
		}

		homeScreen.Visible = true;
	}
}
