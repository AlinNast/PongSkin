using Godot;
using System;

public partial class animTest : Node3D
{

    private AnimationPlayer _animationPlayer;
    
    public override void _Ready()
	{
        
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

      
        foreach (string animName in _animationPlayer.GetAnimationList())
        {
            GD.Print("Found animation: " + animName);
        }
    }

	public override void _Process(double delta)
	{
        
    }

    public void PlayKickAnimation() { if (_animationPlayer.HasAnimation("attack-kick-right")) { _animationPlayer.Play("attack-kick-right"); } else { GD.Print("Animation 'attack-kick-right' not found!"); } }
}
