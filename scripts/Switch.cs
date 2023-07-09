using Godot;
using System;

public partial class Switch : Node
{
	[Signal]
	public delegate void OnEventHandler();
	[Signal]
	public delegate void OffEventHandler();
	[Export]
	bool state = true;
	AnimatedSprite2D sprite;
	public void SetState(bool state){
		this.state = state;
		sprite.Frame = state ? 1: 0;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetChild<AnimatedSprite2D>(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void Toggle(){}
}
