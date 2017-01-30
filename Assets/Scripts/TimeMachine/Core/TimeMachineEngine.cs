using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TimeMachineEngine : MonoBehaviour
{
    [SerializeField] private float _speedRatio = 2.0f;
    [SerializeField] private float _nowTime = 0;
    [SerializeField] private bool _reset = false;

    private void Update()
    {
        #if UNITY_EDITOR
        if(Input.GetKey(KeyCode.A))
        {
            _nowTime -= Time.deltaTime * _speedRatio;
        }

        if(Input.GetKey(KeyCode.D))
        {
            _nowTime += Time.deltaTime * _speedRatio;
        }
        #endif

        CheckReset();
        UpdateTime();
    }

    private void CheckReset()
    {
        if (_reset)
        {
            _reset = false;
            _nowTime = 0;
        }
    }

    private void UpdateTime()
    {
        TimeMachineManager.Instance.Time = _nowTime;
        _nowTime = TimeMachineManager.Instance.Time;
    }
}
