using Godot;
using System;

public partial class HomeButton : TextureButton
{
	[Export] private Control homeScreen;
	
	private PackedScene transition = GD.Load<PackedScene>("res://Phone/Screens/Home Screen/app_close_transition.tscn");
	private double transitionTime = 300f;
	private double startTime;

	private AppCloseTransition _transition;
	
	public override void _Process(double delta)
	{
		if (_transition == null) return;
		
		float t = (float) ((Time.GetTicksMsec() - startTime) / transitionTime);
		if (t > 2f)
		{
			_transition.QueueFree();
			_transition = null;
		}
	}
	
	public void Pressed()
	{
		_transition = (AppCloseTransition) transition.Instantiate();
		_transition.SetTransitionTime(transitionTime);
		_transition.SetEndPos(GlobalPosition);
		Owner.AddChild(_transition);
		
		startTime = Time.GetTicksMsec();
		
		((phone) Owner).LoadScreen(homeScreen);
	}
}
