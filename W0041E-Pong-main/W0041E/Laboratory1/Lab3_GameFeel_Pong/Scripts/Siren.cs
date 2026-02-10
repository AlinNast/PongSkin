using Godot;
using System;

public partial class Siren : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.GlobalRotate(Vector3.Up, (float)delta);
	}
}
