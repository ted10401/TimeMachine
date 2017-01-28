using System;
using System.Collections.Generic;

public class TimelineManager
{
    public static TimelineManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new TimelineManager();
            }

            return _instance;
        }
    }
    private static TimelineManager _instance;

    public float Time
    {
        get { return _time; }
        set
        {
            if (value != _time)
            {
                float deltaTime = value - _time;

                if (deltaTime < 0)
                {
                    while(_reverseActions.Count > 0 && _reverseActions.Peek().m_time >= _time + deltaTime)
                    {
                        float curDeltaTime = _reverseActions.Peek().m_time - _time;
                        UpdateTimeChanged(curDeltaTime);

                        _reverseActions.Pop().m_action();

                        deltaTime -= curDeltaTime;
                    }
                }

                UpdateTimeChanged(deltaTime);

                _time = value;
            }
        }
    }
    private float _time;

    private List<ITimeline> _timelineList;
    private Stack<ReverseAction> _reverseActions;


    public TimelineManager()
    {
        _timelineList = new List<ITimeline>();
        _reverseActions = new Stack<ReverseAction>();
    }


    public void RegisterTimeline(ITimeline timeline)
    {
        _timelineList.Add(timeline);
    }


    public void UnregisterTimeline(ITimeline timeline)
    {
        _timelineList.Remove(timeline);
    }


    public void AddReverseAction(Action action)
    {
        _reverseActions.Push(new ReverseAction(Time, action));
    }


    private void UpdateTimeChanged(float deltaTime)
    {
        foreach (ITimeline timeline in _timelineList)
        {
            timeline.AddTime(deltaTime);
        }
    }
}
