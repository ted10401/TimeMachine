using UnityEngine;

public abstract class BaseTimeline : MonoBehaviour, ITimeline
{
    private void Awake()
    {
        TimelineManager.Instance.RegisterTimeline(this);

        Initialize();
    }

    private void OnDestroy()
    {
        TimelineManager.Instance.UnregisterTimeline(this);
    }

    public virtual void Initialize(){}

    public abstract void AddTime(float deltaTime);
}
