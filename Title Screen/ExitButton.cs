using Godot;
using System;

public partial class ExitButton : BaseButton
{
	public void Pressed()
	{
		GetTree().Quit();
	}
}
