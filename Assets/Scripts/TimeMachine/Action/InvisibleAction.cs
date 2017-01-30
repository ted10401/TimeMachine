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

        TimeMachineManager.Instance.UnregistertimeMachine(GetComponent<ITimeMachine>());
        TimeMachineManager.Instance.AddRewindAction(RewindAction);
    }

    public override void RewindAction()
    {
        _renderer.enabled = true;
        TimeMachineManager.Instance.RegistertimeMachine(GetComponent<ITimeMachine>());
    }
}
