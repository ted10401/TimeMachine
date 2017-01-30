using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TriggerLauncher : BaseLauncher
{
    public enum TriggerType
    {
        Enter,
        Stay,
        Exit,
        None
    }

    [SerializeField] private TriggerType _triggerType = TriggerType.None;

    private void OnTriggerEnter(Collider collider)
    {
        if (_triggerType != TriggerType.Enter)
            return;
        
        Action();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (_triggerType != TriggerType.Stay)
            return;
        
        Action();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (_triggerType != TriggerType.Exit)
            return;
        
        Action();
    }
}
