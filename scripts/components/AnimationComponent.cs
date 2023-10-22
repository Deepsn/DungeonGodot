using System;
using Godot;

namespace DungeonGame.scripts.components;

[GlobalClass]
public partial class AnimationComponent : Node
{
    [Export] public AnimatedSprite2D AnimatedSprite2D;
    [Export] public MovementComponent MovementComponent;

    public override void _Process(double delta)
    {
        var velocity = MovementComponent.Velocity;

        if (velocity.Length() > 0)
        {
            AnimatedSprite2D.FlipH = velocity.X < 0;
            AnimatedSprite2D.Animation = "run";
        }
        else
        {
            AnimatedSprite2D.Animation = "idle";
        }
    }

    public override void _Ready()
    {
        AnimatedSprite2D.Play();
    }
}