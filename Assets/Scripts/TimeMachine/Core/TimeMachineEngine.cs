using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TimeMachineEngine : MonoBehaviour
{
    [SerializeField] private float _speedRatio = 2.0f;
    [SerializeField] private float _nowTime = 0;
    [SerializeField] private bool _reset = false;
    [SerializeField] private bool _rewindEffect = false;

    [Header("Auto Testing")]
    [SerializeField] private bool _auto = false;
    [SerializeField] private float _maxTime = 15f;
    [SerializeField] private float _rewindMultiplier = 2.0f;

    private bool _addTime = true;

    private void Update()
    {
        if (_auto)
        {
            if (_addTime)
            {
                _nowTime += Time.deltaTime * _speedRatio;

                if (_nowTime >= _maxTime)
                {
                    _addTime = false;
                }
            }
            else
            {
                _nowTime -= Time.deltaTime * _speedRatio * _rewindMultiplier;

                if (_nowTime <= 0)
                {
                    _nowTime = 0;
                    _auto = false;
                    _addTime = true;
                }
            }
        }
        else
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

            if(Input.GetKey(KeyCode.Space))
            {
                _auto = true;
            }
            #endif
        }

        CheckReset();
        UpdateRewindEffect();
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

    private void UpdateRewindEffect()
    {
        TimeMachineManager.Instance.RewindEffect = _rewindEffect;
    }

    private void UpdateTime()
    {
        TimeMachineManager.Instance.Time = _nowTime;
    }
}
