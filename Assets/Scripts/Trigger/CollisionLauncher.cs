using UnityEngine;

public class CollisionLauncher : BaseLauncher
{
    public enum CollisionType
    {
        Enter,
        Stay,
        Exit,
        None
    }

    [SerializeField] private CollisionType _collisionType = CollisionType.None;

    private void OnCollisionEnter(Collision collision)
    {
        if (_collisionType != CollisionType.Enter)
            return;

        Action();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_collisionType != CollisionType.Stay)
            return;
        
        Action();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (_collisionType != CollisionType.Exit)
            return;
        
        Action();
    }
}
