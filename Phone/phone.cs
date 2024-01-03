using Godot;
using System;

public partial class phone : Control
{
	[Export]
	private Control contentRoot;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void LoadScreen(int i)
	{
		foreach (Control screen in contentRoot.GetChildren())
		{
			screen.SetProcess(false);
			screen.Hide();
		}

		Control s = (Control) contentRoot.GetChild(i);
		s.SetProcess(true);
		s.Show();
	}

	public void _on_back_pressed()
	{
		LoadScreen(1);
		GD.Print("test");
	}
}
