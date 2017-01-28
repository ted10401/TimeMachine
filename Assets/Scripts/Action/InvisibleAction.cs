using UnityEngine;

public class InvisibleAction : BaseAction
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public override void Action()
    {
        if (null == _renderer)
            return;

        _renderer.enabled = false;
        TimelineManager.Instance.UnregisterTimeline(GetComponent<ITimeline>());

        TimelineManager.Instance.AddReverseAction(ReverseAction);
    }

    public override void ReverseAction()
    {
        _renderer.enabled = true;
        TimelineManager.Instance.RegisterTimeline(GetComponent<ITimeline>());
    }
}
