using System;

public class RewindAction
{
    public float m_time;
    public Action m_action;

    public RewindAction(float time, Action action)
    {
        m_time = time;
        m_action = action;
    }
}
