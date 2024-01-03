using Godot;
using System;

public partial class OpenApp : LinkButton
{
	public bool isFake = false;
	
	private PackedScene transition = GD.Load<PackedScene>("res://Phone/Screens/Home Screen/app_open_transition.tscn");
	
	private double startTime;
	private double transitionTime = 1500f;

	private Vector2 endPos = new Vector2(249, 591);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		startTime = Time.GetTicksMsec();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!isFake) return;
		
		float t = (float) ((Time.GetTicksMsec() - startTime) / transitionTime);
		t = Mathf.Clamp(t, 0, 1);
	
		Position = Position.Lerp(endPos, t);
	}

	public void OnPressed()
	{
		if (isFake) return;
		
		Control instance = (Control) transition.Instantiate();
		instance.GlobalPosition = GlobalPosition;
		Owner.AddChild(instance);
		
		OpenApp dup = (OpenApp) Duplicate();
		dup.GlobalPosition = GlobalPosition;
		dup.isFake = true;
		Owner.AddChild(dup);
		
		
	}
}
