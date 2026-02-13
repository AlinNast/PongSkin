using Godot;
using System;

public partial class Siren : Node3D
{
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
        
        this.GlobalRotate(Vector3.Up, (float)delta);
	}
}
