using Godot;
using System;

public partial class OpenApp : LinkButton
{
	[Export] public Control screen;
	public Control homeScreen;
	public bool isFake = false;
	
	private PackedScene transition = GD.Load<PackedScene>("res://Phone/Screens/Home Screen/app_open_transition.tscn");
	
	private double startTime;
	private double transitionTime = 300f;

	private Vector2 startPos;
	private Vector2 endPos = new(249, 591);

	private AppOpenTransition _transition;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		startTime = Time.GetTicksMsec();
		startPos = Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!isFake) return;
		
		float t = (float) ((Time.GetTicksMsec() - startTime) / transitionTime);
		if (t > 2f)
		{
			homeScreen.Visible = false;
			screen.Visible = true;
			_transition.QueueFree();
			QueueFree();
			return;
		}
		
		t = Mathf.Clamp(t, 0, 1);
		t = Mathf.BezierInterpolate(0, 1, 1, 1, t);
	
		Position = startPos.Lerp(endPos, t);
	}

	public void OnPressed()
	{
		if (isFake) return;
		
		AppOpenTransition instance = (AppOpenTransition) transition.Instantiate();
		instance.GlobalPosition = GlobalPosition;
		instance.SetTransitionTime(transitionTime);
		Owner.AddChild(instance);
		
		OpenApp dup = (OpenApp) Duplicate();
		dup.GlobalPosition = GlobalPosition;
		dup.isFake = true;
		dup.screen = screen;
		dup._transition = instance;
		dup.homeScreen = (Control) Owner;
		Owner.AddChild(dup);
		
		GD.Print(GlobalPosition);
	}
}
