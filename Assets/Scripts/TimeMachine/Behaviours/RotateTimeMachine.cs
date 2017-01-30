using UnityEngine;

public class RotateTimeMachine : BaseTimeMachine
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    public override void UpdateTime(float deltaTime)
    {
        transform.Rotate(_direction.normalized * _speed * deltaTime);
    }
}
