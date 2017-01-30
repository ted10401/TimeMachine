using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    public void Awake()
    {
        Initialize();
    }

    public abstract void Initialize();
    public abstract void Action();
    public abstract void RewindAction();
}
