using Godot;
using System;

public partial class OpenSettings : TextureButton
{
	[Export] public Control settingScreen;
	
	private PackedScene transition = GD.Load<PackedScene>("res://Phone/Screens/Home Screen/app_open_transition.tscn");
	private double transitionTime = 300f;
	private double startTime;

	private AppOpenTransition _transition;
	
	public override void _Process(double delta)
	{
		if (_transition == null) return;
		
		float t = (float) ((Time.GetTicksMsec() - startTime) / transitionTime);
		if (t > 2f)
		{
			((phone) Owner).LoadScreen(settingScreen);
			_transition.QueueFree();
			_transition = null;
		}
	}
	
	public void Pressed()
	{
		_transition = (AppOpenTransition) transition.Instantiate();
		_transition.GlobalPosition = GlobalPosition;
		_transition.SetTransitionTime(transitionTime);
		Owner.AddChild(_transition);
		
		startTime = Time.GetTicksMsec();
	}
}
