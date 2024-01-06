using Godot;
using System;

public partial class SetInitWindowSize : Window
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		int yres = DisplayServer.ScreenGetSize().Y;
		GD.Print(yres);
		yres = Mathf.RoundToInt(yres * 0.925f);
		Size = new Vector2I(yres * 648/1332, yres);
	}
}
