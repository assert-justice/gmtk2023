using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	double speed = 300;
	[Export]
	double jumpPower = 300;
	[Export]
	int maxJumps = 2;
	int jumps = 0;
	[Export]
	double gravity = 10;
	[Export]
	double coyoteTime = 0.3;
	double coyoteClock = 0;
	AnimatedSprite2D sprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetChild<AnimatedSprite2D>(0);
	}

	bool UpdateCanJump(){
		if(IsOnFloor()) return true;
		if(coyoteClock > 0) {
			coyoteClock = 0;
			return true;
		}
		if(jumps > 0){
			jumps--;
			return true;
		}
		return false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(IsOnFloor()) {
			jumps = maxJumps;
			coyoteClock = coyoteTime;
		}
		if(coyoteClock > 0) coyoteClock -= delta;
		var hSpeed = Input.GetAxis("left", "right") * speed;
		var vSpeed = Velocity.Y + gravity;
		if(Input.IsActionJustPressed("jump") && UpdateCanJump()){
			vSpeed = -jumpPower;
		}
		Velocity = new Vector2((float)hSpeed, (float)vSpeed);
		if(Velocity.X < 0) sprite.FlipH = false;
		if(Velocity.X > 0) sprite.FlipH = true;
		if(Velocity.X == 0 || !IsOnFloor()) sprite.Stop();
		else sprite.Play();
		MoveAndSlide();
	}
}
