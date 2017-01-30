using UnityEngine;

public class InvisibleAction : BaseAction
{
    private Renderer _renderer;

    public override void Initialize()
    {
        _renderer = GetComponent<Renderer>();
    }

    public override void Action()
    {
        if (null == _renderer)
            return;

        if (!_renderer.enabled)
            return;

        _renderer.enabled = false;

        TimeMachineManager.Instance.AddRewindAction(RewindAction);
    }

    public override void RewindAction()
    {
        _renderer.enabled = true;
    }
}
