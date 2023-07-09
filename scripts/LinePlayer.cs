using Godot;
using System;

public partial class LinePlayer : Label
{
	AudioStreamPlayer audio;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		audio = GetChild<AudioStreamPlayer>(1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetLine(Godot.Collections.Dictionary<string,string> dict, string key){
		if(dict.ContainsKey("message")){
			Text = dict["message"];
		}
		else{
			GD.PrintErr($"The object at '${key}' does not have a message field. That's probably an error.");
		}
		if(dict.ContainsKey("filename")){
			// load and play audio
		}
	}
}
