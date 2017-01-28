using System;

public class ReverseAction
{
    public float m_time;
    public Action m_action;

    public ReverseAction(float time, Action action)
    {
        m_time = time;
        m_action = action;
    }
}
