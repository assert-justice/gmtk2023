using Godot;
using System;

public partial class MainMenu : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public override void _Process(double delta)
	{
	}
	private void _on_button_button_down()
	{
		// Replace with function body.
		var lineSource = GetNode("Lines");
		GD.Print(lineSource.Call("get_message", "text"));

	}
	public void SetMessage(string key){
		var lineSource = GetNode("Lines");
		var text = lineSource.Call("get_message", key, false).ToString();
		if(text == "None") return;
	}
}
