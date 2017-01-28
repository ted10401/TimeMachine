using UnityEngine;

public class RotateTimeline : BaseTimeline
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    public override void AddTime(float deltaTime)
    {
        transform.localEulerAngles += _direction.normalized * _speed * deltaTime;
    }
}
