using Godot;
using System;

public partial class AppCloseTransition : Control
{
	private double startTime;
	private Vector2 endPos;
	private double transitionTime = 1500f;

	public void SetTransitionTime(double time)
	{
		transitionTime = time;
	}

	public void SetEndPos(Vector2 pos)
	{
		endPos = pos;
	}
	
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
		t = Mathf.BezierInterpolate(0, 1, 1, 1, t);
		
		GD.Print(endPos);
		Position = Vector2.Zero.Lerp(endPos, t);
		Scale = Vector2.One.Lerp(Vector2.Zero, t);
	}
}
