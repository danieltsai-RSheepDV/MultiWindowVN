using Godot;
using System;

public partial class Scroll : VBoxContainer
{
	PackedScene text = GD.Load<PackedScene>("res://Phone/Screens/Messenger/TextBoxes/text.tscn");
	PackedScene iText = GD.Load<PackedScene>("res://Phone/Screens/Messenger/TextBoxes/incomingText.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void GenerateTextbox(string dialogueText, bool isRight)
	{
		TextBox t = (TextBox) (isRight ? text.Instantiate() : iText.Instantiate());
		t.SetText(dialogueText);
		AddChild(t);
		MoveChild(t, -2);
	}
}
