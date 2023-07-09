using Godot;
using System;

public partial class Flag : Node
{
	[Export]
	string message = "intro";
	MainMenu main;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var sprite = GetChild<AnimatedSprite2D>(0);
		sprite.Play();
		main = GetTree().Root.GetNode("Main") as MainMenu;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }
	private void _on_area_2d_body_entered(Node2D body)
	{
		// Replace with function body.
		var player = body as Player;
		if(player == null) return;
		main.SetMessage(message);
	}
}


