using Godot;
using System;

public partial class LinePlayer : Label
{
	double showTime = 0;
	bool done = false;
	bool won = false;
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
		if(key == "done") done = true;
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
			showTime = 100;
			var stream = GD.Load<AudioStream>(filename);
			audio.Stream = stream;
			audio.Play();
		}
	}
	public void Win(){
		audio.Stream = GD.Load<AudioStream>("res://music/awesomeness.wav");
		audio.Play();
		won = true;
	}
	private void _on_audio_stream_player_finished()
	{
		// Replace with function body.
		showTime = 0;
		Visible = false;
		if(won) GetTree().Quit();
		else if(done) {
			Win();
			// GetParent().GetNode<Control>("Credits").Visible = true;
		}
	}
}


