using UnityEngine;

public class TrailRendererTimeMachine : BaseTimeMachine
{
    private TrailRenderer _trailRenderer;

    public override void Initialize()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    public override void UpdateTime(float deltaTime)
    {
        _trailRenderer.enabled = deltaTime > 0;
    }
}
