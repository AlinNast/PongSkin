using Godot;
using System;

public partial class HelicopterSpotlight : SpotLight3D
{
    [Export] public Node3D Target;
    bool isSkinOn = true;

    public override void _Ready()
	{
        this.Visible = isSkinOn;

    }

    public override void _Process(double delta)
	{
        if (Input.IsActionJustPressed("Switch"))
        {
            isSkinOn = (isSkinOn) ? false : true;
            this.Visible = isSkinOn;
        }

        if (Target != null)
        {
            Vector3 targetPos = Target.GlobalPosition;

            // make the light look at the target position, but add a small offset to make a helicoper effect
            LookAt(targetPos + new Vector3(0, 0.0001f, 0), Vector3.Up);
        }
    }
}
