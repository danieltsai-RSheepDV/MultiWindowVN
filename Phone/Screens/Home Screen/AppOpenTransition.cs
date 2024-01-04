using Godot;
using System;

public partial class AppOpenTransition : Control
{
	private double startTime;
	private Vector2 startPos;
	private double transitionTime = 1500f;

	public void SetTransitionTime(double time)
	{
		transitionTime = time;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		startTime = Time.GetTicksMsec();
		startPos = Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float t = (float) ((Time.GetTicksMsec() - startTime) / transitionTime);
		t = Mathf.Clamp(t, 0, 1);
		t = Mathf.BezierInterpolate(0, 1, 1, 1, t);
		
		Position = startPos.Lerp(Vector2.Zero, t);
		Scale = Vector2.Zero.Lerp(Vector2.One, t);

	}
}
