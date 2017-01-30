using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayScaleImageEffect : BaseImageEffect
{
    public static GrayScaleImageEffect Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = Camera.main.gameObject.AddComponent<GrayScaleImageEffect>();
            }

            return _instance;
        }
    }
    private static GrayScaleImageEffect _instance;

    public bool IsRewindTime { set { _isRewindTime = value; } }

    private string _saturationPropertyName = "_saturation";
    private int _saturationID;

    private bool _isRewindTime = false;
    private float _saturation = 1f;
    private float _speedRatio = 5.0f;

    public override void Awake()
    {
        _shaderName = "Hidden/GrayScaleImageEffectShader";
        base.Awake();
    }


    public override void InitPropertyIDs()
    {
        _saturationID = Shader.PropertyToID(_saturationPropertyName);
        UpdateSaturation();
    }


    private void Update()
    {
        if (_isRewindTime)
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
