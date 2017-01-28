using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayScaleImageEffect : BaseImageEffect
{
    public static GrayScaleImageEffect Instance
    {
        get { return _instance; }
    }
    private static GrayScaleImageEffect _instance;

    public bool ReverseTime { set { _reverseTime = value; } }

    [Range(0f, 1f)]
    [SerializeField] private float _saturation = 1.0f;
    [SerializeField] private float _speedRatio = 2.0f;

    private string _saturationPropertyName = "_saturation";
    private int _saturationID;
    private bool _reverseTime = false;

    public override void Awake()
    {
        _instance = this;

        base.Awake();
    }


    public override void InitPropertyIDs()
    {
        _saturationID = Shader.PropertyToID(_saturationPropertyName);
    }


    private void Update()
    {
        if (_reverseTime)
        {
            _saturation -= Time.deltaTime * _speedRatio;
        }
        else
        {
            _saturation += Time.deltaTime * _speedRatio;
        }

        UpdateSaturation();
    }

    private void UpdateSaturation()
    {
        _saturation = Mathf.Clamp01(_saturation);
        _material.SetFloat(_saturationID, _saturation);
    }
}
