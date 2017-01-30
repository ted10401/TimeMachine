using UnityEngine;

public abstract class BaseTimeMachine : MonoBehaviour, ITimeMachine
{
    private void Awake()
    {
        TimeMachineManager.Instance.RegistertimeMachine(this);

        Initialize();
    }


    private void OnDestroy()
    {
        TimeMachineManager.Instance.UnregistertimeMachine(this);
    }


    public virtual void Initialize(){}
    public abstract void UpdateTime(float deltaTime);
}
