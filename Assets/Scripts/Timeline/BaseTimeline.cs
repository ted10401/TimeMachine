using UnityEngine;

public abstract class BaseTimeline : MonoBehaviour, ITimeline
{
    private void Awake()
    {
        TimelineManager.Instance.RegisterTimeline(this);
    }

    private void OnDestroy()
    {
        TimelineManager.Instance.UnregisterTimeline(this);
    }

    public abstract void AddTime(float deltaTime);
}
