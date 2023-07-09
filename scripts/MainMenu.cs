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
		SetMessage("text");
	}
	public void SetMessage(string key){
		var lineSource = GetNode("Lines");
		var res = lineSource.Call("get_message", key, false, false).AsGodotDictionary<string, string>();
		linePlayer.SetLine(res, key);
	}
}
