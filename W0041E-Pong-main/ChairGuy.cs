using Godot;
using System;

public partial class ChairGuy : Node3D
{
    private Vector3 _lastPosition;

    public override void _Ready()
	{
        _lastPosition = GlobalPosition;

    }

    public override void _Process(double delta)
	{
        Vector3 velocity = _lastPosition - GlobalPosition;
        if (velocity.LengthSquared() > 0.00001f)
        { 
            //GD.Print("Velocity: " + velocity);
            Vector3 direction = velocity.Normalized();

            // Get the current scale before we change anything
            Vector3 currentScale = GlobalBasis.Scale;

            // Create the new rotation basis
            Basis newBasis = Basis.LookingAt(direction, Vector3.Up);

            // Re-apply the scale to that new basis
            // This multiplies the rotation vectors by your original scale
            GlobalBasis = newBasis.Scaled(currentScale);
        }

        // Store current position for the next frame's calculation
        _lastPosition = GlobalPosition;

    }
}
