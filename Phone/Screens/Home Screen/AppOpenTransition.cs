using Godot;
using System;

public partial class AppOpenTransition : Control
{
	private double startTime;
	private double transitionTime = 1500f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		startTime = Time.GetTicksMsec();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float t = (float) ((Time.GetTicksMsec() - startTime) / transitionTime);
		t = Mathf.Clamp(t, 0, 1);
		
		Position = Position.Lerp(Vector2.Zero, t);
		Scale = Scale.Lerp(Vector2.One, t);

	}
}
