using Godot;
using System;

public partial class LinePlayer : Label
{
	double showTime = 0;
	AudioStreamPlayer audio;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		audio = GetChild<AudioStreamPlayer>(1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(showTime > 0){
			showTime -= delta;
			if(showTime <= 0) Visible = false;
		}
	}

	public void SetLine(Godot.Collections.Dictionary<string,string> dict, string key){
		if(dict.ContainsKey("message")){
			Text = dict["message"];
		}
		else{
			GD.PrintErr($"The object at '${key}' does not have a message field. That's probably an error.");
		}
		Visible = true;
		showTime = 5;
		if(dict.ContainsKey("filename")){
			// load and play audio
		}
		else{
			showTime = 5;
		}
	}
}
