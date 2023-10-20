using Godot;

namespace DungeonGame.scripts.components;

public partial class MovementComponent : Node2D
{
	[Export] public CharacterBody2D Player;
	[Export] public float Speed = 400;

	public override void _Process(double delta)
	{
		var horizontal = Input.GetAxis("move_left", "move_right");
		var vertical = Input.GetAxis("move_up", "move_down");
		var velocity = new Vector2(horizontal, vertical);

		var animatedSprite2D = Player.GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;

			animatedSprite2D.FlipH = velocity.X < 0;
			animatedSprite2D.Animation = "run";
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Pause();
		}

		Player.Velocity += velocity * (float)delta;
		Player.MoveAndSlide();
	}
}
