using Godot;
using System;

public partial class Siren : Node3D
{
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
        
        this.GlobalRotate(Vector3.Up, (float)delta);
	}
}
