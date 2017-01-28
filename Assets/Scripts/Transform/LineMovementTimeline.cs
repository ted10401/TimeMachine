using UnityEngine;

public class LineMovementTimeline : BaseTimeline
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

    public override void AddTime(float deltaTime)
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
