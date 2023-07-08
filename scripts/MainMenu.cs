using Godot;
using System;

public partial class MainMenu : Node
{
	LinePlayer linePlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		linePlayer = GetChild<LinePlayer>(2);
	}

	public override void _Process(double delta)
	{
	}
	private void _on_button_button_down()
	{
		// Replace with function body.
		// var lineSource = GetNode("Lines");
		// GD.Print(lineSource.Call("get_message", "text"));
		SetMessage("text");

	}
	public void SetMessage(string key){
		var lineSource = GetNode("Lines");
		// var text = lineSource.Call("get_message", key, false).ToString();
		var res = lineSource.Call("get_message", key, false, false).AsGodotDictionary<string, string>();
		// if(res.Count == 0) {
		// 	GD.PrintErr($"Could not get message from key '{key}'");
		// 	return;
		// }
		linePlayer.SetLine(res, key);
	}
}
