using Godot;
using System;

public partial class MainCamera : Camera3D
{
    private float _defaultHeight;
    private Tween _activeTween;

    public override void _Ready()
    {
        _defaultHeight = GlobalPosition.Y;
    }

    public void PlayRespawnLerp()
    {
        // 1. Kill any existing tween to avoid conflicts
        if (_activeTween != null && _activeTween.IsRunning())
        {
            _activeTween.Kill();
        }

        // 2. Set starting position (half height)
        Vector3 startPos = GlobalPosition;
        startPos.Y = _defaultHeight * 0.5f;
        GlobalPosition = startPos;

        // 3. Create the Tween to lerp back to default height
        _activeTween = GetTree().CreateTween();

        // We use "TransCubic" and "EaseOut" for a smooth, professional feel
        _activeTween.TweenProperty(this, "global_position:y", _defaultHeight, 1.2f)
            .SetTrans(Tween.TransitionType.Cubic)
            .SetEase(Tween.EaseType.Out);
    }
}
