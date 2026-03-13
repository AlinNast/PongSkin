using Godot;
using System;

public partial class ChairGuy : Node3D
{
    private Vector3 _lastPosition;
    public float StretchStrength = 0.05f; // How much it stretches based on speed
    public float SquashStrength = 2f;   // How much it squashes on impact
    public float RecoverySpeed = 10.0f;   // How fast it returns to normal (Lerp weight)

    private Vector3 _targetScale = Vector3.One;

    public override void _Ready()
	{
        _lastPosition = GlobalPosition;

    }

    public override void _Process(double delta)
	{
        Vector3 velocity = (_lastPosition - GlobalPosition) / (float)delta;
        float speed = velocity.Length();
        if (speed > 0.1f)
        { 
            //GD.Print("Velocity: " + velocity);
            Vector3 direction = velocity.Normalized();

            float baseScale = 0.3f;

            // Elongate forward, shrink sides
            // Volume preservation: x * y * z = 1
            float stretchAmount = speed * StretchStrength;
            float zScale = baseScale + stretchAmount;
            float xyScale = (baseScale * baseScale * baseScale) / (zScale * zScale);
            _targetScale = new Vector3(xyScale, xyScale, zScale);


            // Get the current scale before we change anything
            // Vector3 currentScale = GlobalBasis.Scale + new Vector3(0.0f, 0.0f, 0.01f);

            // Create the new rotation basis
            Basis rotationBasis = Basis.LookingAt(direction, Vector3.Up);

            // Re-apply the scale to that new basis
            // This multiplies the rotation vectors by your original scale
            GlobalBasis = rotationBasis * Basis.FromScale(_targetScale);
        }
        else
        {
            _targetScale = new Vector3(0.3f, 0.3f, 0.3f);
            // Smoothly return to 0.3 when stopped
            GlobalBasis = GlobalBasis.Scaled(GlobalBasis.Scale.Lerp(_targetScale, RecoverySpeed * (float)delta));
        }

       


        // Store current position for the next frame's calculation
        _lastPosition = GlobalPosition;

    }

    public void OnCollisionImpact()
    {
        GD.Print("Collision Impact!");
        float baseScale = 0.3f;
        // Calculate our squash values
        float zSquash = baseScale * (1.0f - SquashStrength);
        float xySquash = baseScale * (1.0f + SquashStrength);
        Vector3 squashScale = new Vector3(xySquash, xySquash, zSquash);
        Vector3 normalScale = new Vector3(baseScale, baseScale, baseScale);

        // (This is the easy 'lerp' over time)
        Tween tween = GetTree().CreateTween();

        // very quickly squash
        tween.TweenProperty(this, "scale", squashScale, 0.05f)
             .SetTrans(Tween.TransitionType.Expo)
             .SetEase(Tween.EaseType.Out);

        //  ease back
        tween.TweenProperty(this, "scale", normalScale, 0.5f)
             .SetTrans(Tween.TransitionType.Elastic)
             .SetEase(Tween.EaseType.Out);
    }
}
