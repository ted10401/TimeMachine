using UnityEngine;

public class BaseLauncher : MonoBehaviour
{
    protected BaseAction[] _actions;

    private void Awake()
    {
        _actions = GetComponents<BaseAction>();
    }


    protected void Action()
    {
        for (int count = 0; count < _actions.Length; count++)
        {
            _actions[count].Action();
        }
    }
}
