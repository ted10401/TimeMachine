using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TimelineEngine : MonoBehaviour
{
    [SerializeField] private float _speedRatio = 2.0f;
    [SerializeField] private float _nowTime = 0;
    [SerializeField] private bool _setZero = false;

    private void Update()
    {
        CheckSetZero();
        UpdateTimelineDependants();

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
    }

    private void CheckSetZero()
    {
        if (_setZero)
        {
            _setZero = false;
            _nowTime = 0;
        }
    }

    private void UpdateTimelineDependants()
    {
        TimelineManager.Instance.Time = _nowTime;
        _nowTime = TimelineManager.Instance.Time;
    }
}
