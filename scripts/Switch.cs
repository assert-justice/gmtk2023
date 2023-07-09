using Godot;
using System;

public partial class Switch : Usable
{
	[Signal]
	public delegate void OnEventHandler();
	[Signal]
	public delegate void OffEventHandler();
	[Export]
	bool state = false;
	AnimatedSprite2D sprite;
	public void SetState(bool state){
		this.state = state;
		sprite.Frame = state ? 1: 0;
		if(state)EmitSignal(SignalName.On);
		else EmitSignal(SignalName.Off);
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetChild<AnimatedSprite2D>(0);
		SetState(state);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void Toggle(){
		SetState(!state);
	}
	protected override void _Use()
	{
		base._Use();
		Toggle();
	}
	
	private void _on_area_2d_body_entered(Node2D body)
	{
		// Replace with function body.
		var player = body as Player;
		if(player == null) return;
		player.AddTarget(this);
	}


	private void _on_area_2d_body_exited(Node2D body)
	{
		// Replace with function body.
		var player = body as Player;
		if(player == null) return;
		player.RemoveTarget(this);
	}
}


