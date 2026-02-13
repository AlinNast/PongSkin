using Godot;
using System;

public partial class HelicopterSpotlight : SpotLight3D
{
    [Export] public Node3D Target;
    bool isSkinOn = true;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        this.Visible = isSkinOn;

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
        if (Input.IsActionJustPressed("Switch"))
        {
            isSkinOn = (isSkinOn) ? false : true;
            this.Visible = isSkinOn;
        }

        if (Target != null)
        {
            // 1. Get the target's current position
            Vector3 targetPos = Target.GlobalPosition;

            // 2. Make the light look at that position
            // Vector3.Up ensures the light doesn't "spin" on its Z-axis
            LookAt(targetPos + new Vector3(0, 0.0001f, 0), Vector3.Up);
        }
    }
}
