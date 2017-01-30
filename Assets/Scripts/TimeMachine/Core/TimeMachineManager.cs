using System;
using System.Collections.Generic;

public class TimeMachineManager
{
    public static TimeMachineManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new TimeMachineManager();
            }

            return _instance;
        }
    }
    private static TimeMachineManager _instance;

    public float Time
    {
        get { return _time; }
        set
        {
            if (value != _time)
            {
                float deltaTime = value - _time;

                if(RewindEffect)
                {
                    GrayScaleImageEffect.Instance.IsRewindTime = deltaTime < 0;
                }

                if (deltaTime < 0)
                {
                    while(_rewindActions.Count > 0 && _rewindActions.Peek().m_time >= _time + deltaTime)
                    {
                        float curDeltaTime = _rewindActions.Peek().m_time - _time;
                        UpdateTime(curDeltaTime);

                        _rewindActions.Pop().m_action();
                        deltaTime -= curDeltaTime;
                    }
                }

                UpdateTime(deltaTime);

                _time = value;
            }
        }
    }
    private float _time;

    public bool RewindEffect
    {
        get { return _rewindEffect; }
        set { _rewindEffect = value; }
    }
    private bool _rewindEffect = false;

    private List<ITimeMachine> _timeMachineList;
    private Stack<RewindAction> _rewindActions;


    public TimeMachineManager()
    {
        _timeMachineList = new List<ITimeMachine>();
        _rewindActions = new Stack<RewindAction>();
    }


    public void RegistertimeMachine(ITimeMachine timeMachine)
    {
        _timeMachineList.Add(timeMachine);
    }


    public void UnregisterTimeMachine(ITimeMachine timeMachine)
    {
        _timeMachineList.Remove(timeMachine);
    }


    public void AddRewindAction(Action action)
    {
        _rewindActions.Push(new RewindAction(Time, action));
    }


    private void UpdateTime(float deltaTime)
    {
        foreach (ITimeMachine timeMachine in _timeMachineList)
        {
            timeMachine.UpdateTime(deltaTime);
        }
    }
}
