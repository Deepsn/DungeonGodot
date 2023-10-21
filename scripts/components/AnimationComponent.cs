using Godot;

namespace DungeonGame.scripts.components;

public partial class AnimationComponent : Node
{
    [Export] public AnimatedSprite2D AnimatedSprite2D;
    [Export] public MovementComponent MovementComponent;

    public override void _Process(double delta)
    {
        var velocity = MovementComponent.Velocity;

        AnimatedSprite2D.FlipH = velocity.X < 0;
        AnimatedSprite2D.Animation =
            velocity.Length() > 0
                ? "run"
                : "idle";
    }

    public override void _Ready()
    {
        AnimatedSprite2D.Play();
    }
}