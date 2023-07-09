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
		if(dict.Count == 0) return;
		if(dict.ContainsKey("message")){
			Text = dict["message"];
		}
		else{
			GD.PrintErr($"The object at '${key}' does not have a message field. That's probably an error.");
		}
		Visible = true;
		var filename = "None";
		if(dict.ContainsKey("filename")){
			filename = dict["filename"];
		}
		if(filename == "None"){
			showTime = 10;
		}
		else{
			// load and play audio
		}
	}
	public void Win(){
		audio.Stream = GD.Load<AudioStream>("res://music/awesomeness.wav");
		audio.Play();
	}
}
