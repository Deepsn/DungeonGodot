using Godot;

namespace DungeonGame.scripts.components;

[GlobalClass]
public partial class MovementComponent : Node
{
	[Export] public CharacterBody2D Entity;
	[Export] public float Speed = 70;

	public Vector2 Velocity;

	public override void _Process(double delta)
	{
		var horizontal = Input.GetAxis("move_left", "move_right");
		var vertical = Input.GetAxis("move_up", "move_down");
		Velocity = new Vector2(horizontal, vertical);

		if (Velocity.Length() > 0)
		{
			Velocity = Velocity.Normalized() * Speed;
		}

		Entity.Velocity = Velocity * (float)delta;
		Entity.MoveAndSlide();
	}
}
