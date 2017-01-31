using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    private void Awake()
    {
        Initialize();
    }

    protected abstract void Initialize();
    public abstract void Action();
    public abstract void RewindAction();
}
