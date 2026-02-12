using Godot;
using System;

public partial class animTest : Node3D
{

    private AnimationPlayer _animationPlayer;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        // Path to the AnimationPlayer depends on your scene structure.
        // If it's a direct child of the node this script is on:
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

        // Optional: List all available animation names to the console 
        // to make sure you have the right strings.
        foreach (string animName in _animationPlayer.GetAnimationList())
        {
            GD.Print("Found animation: " + animName);
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        
    }

    public void PlayKickAnimation() { if (_animationPlayer.HasAnimation("attack-kick-right")) { _animationPlayer.Play("attack-kick-right"); } else { GD.Print("Animation 'attack-kick-right' not found!"); } }
}
