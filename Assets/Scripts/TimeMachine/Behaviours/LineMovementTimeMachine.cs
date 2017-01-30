using UnityEngine;

public class LineMovementTimeMachine : BaseTimeMachine
{
    public Vector3 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    [SerializeField] private bool _local;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    public override void UpdateTime(float deltaTime)
    {
        if (_local)
        {
            transform.localPosition += _direction.normalized * _speed * deltaTime;
        }
        else
        {
            transform.position += _direction.normalized * _speed * deltaTime;
        }
    }
}
