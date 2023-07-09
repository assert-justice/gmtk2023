using Godot;
using System;

public partial class MainMenu : Node
{
	LinePlayer linePlayer;
	Control mainMenu;
	Control pauseMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		linePlayer = GetNode<LinePlayer>("LinePlayer");
		mainMenu = GetNode<Control>("MainMenu");
		pauseMenu = GetNode<Control>("PauseMenu");
		// SetMessage("intro");
	}

	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("pause")){
			if(mainMenu.Visible) return;
			PauseToggle();
		}
	}
	void PauseToggle(){
		pauseMenu.Visible = !pauseMenu.Visible;
		// GetTree().Paused = pauseMenu.Visible;
	}
	private void _on_button_button_down()
	{
		// Win();
		var gameHolder = GetNode("GameHolder");
		gameHolder.AddChild(GD.Load<PackedScene>("res://game.tscn").Instantiate());
		SetMessage("intro");
		mainMenu.Visible = false;
	}
	public void SetMessage(string key, bool random = false, bool destructive = true){
		var lineSource = GetNode("Lines");
		var res = lineSource.Call("get_message", key, random, destructive).AsGodotDictionary<string, string>();
		linePlayer.SetLine(res, key);
	}
	private void _on_timer_timeout()
	{
		// Replace with function body.
		SetMessage("control_basics");
	}
	public void Win(){
		linePlayer.Win();
	}
	private void _on_quit_button_down()
	{
		// Replace with function body.
		GetTree().Quit();
	}
	private void _on_resume_button_down()
	{
		// Replace with function body.
		PauseToggle();
	}
}
