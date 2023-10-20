using Godot;

namespace DungeonGame.scripts.components;

public partial class MovementComponent : Node2D
{
	[Export] public Area2D Player;
	[Export] public float Speed = 400;

	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;

		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;

		}

		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}

		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}

		var animatedSprite2D = Player.GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;

			animatedSprite2D.Animation = "run";
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Pause();
		}

		animatedSprite2D.FlipH = velocity.X < 0;

		GD.Print("velocity", velocity);
		Player.Position += velocity * (float)delta;
	}
}
