using Godot;
using System;

public partial class Game : Node
{
	[Export]
	PackedScene[] scenes;
	int level = 0;
	void LoadLevel(){
		if(GetChildCount() > 0) GetChild(0).QueueFree();
		if(level >= 0 && level < scenes.Length){
			var temp = scenes[level].Instantiate();
			AddChild(temp);
		}
	}
	public void IncLevel(){
		level++;
		LoadLevel();
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		LoadLevel();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
