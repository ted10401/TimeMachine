using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemTimeline : BaseTimeline
{
    private ParticleSystem _particleSystem;
    private float _time;

    public override void Initialize()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.randomSeed = 1;
    }


    public override void AddTime(float deltaTime)
    {
        _time += deltaTime;

        _particleSystem.Simulate(_time);
    }
}
