using UnityEngine;
using System.Collections.Generic;

public class InstantiateAction : BaseAction
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _instantiateNumber = 1;

    private List<GameObject> _instances;

    private void Awake()
    {
        _instances = new List<GameObject>();
    }


    public override void Action()
    {
        GameObject cacheObj = null;
        LineMovementTimeMachine cacheTimeline = null;
        LineMovementTimeMachine thisTimeline = null;
        thisTimeline = GetComponent<LineMovementTimeMachine>();

        for (int count = 0; count < _instantiateNumber; count++)
        {
            cacheObj = Instantiate<GameObject>(_prefab);
            cacheObj.transform.SetParent(transform.parent);
            cacheObj.transform.position = GetRandomPosition(transform.position);

            cacheTimeline = cacheObj.GetComponent<LineMovementTimeMachine>();

            if (null != cacheTimeline && null != thisTimeline)
            {
                cacheTimeline.Speed = thisTimeline.Speed;
                cacheTimeline.Direction = thisTimeline.Direction;
            }

            _instances.Add(cacheObj);
        }

        TimeMachineManager.Instance.AddRewindAction(RewindAction);
    }

    public override void RewindAction()
    {
        foreach (GameObject go in _instances)
        {
            Destroy(go);
        }
    }

    private Vector3 GetRandomPosition(Vector3 position)
    {
        return position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
    }
}
