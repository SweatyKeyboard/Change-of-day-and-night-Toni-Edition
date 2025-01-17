using UnityEngine;

public class TimeEvents : MonoBehaviour
{
    [SerializeField] private TimeData _data;
    [SerializeField] private EventTime[] _events;

    private int _indexCurrentEvent;

    private void Awake()
    {
        _indexCurrentEvent = 0;
        StartEvent(_indexCurrentEvent);
    }

    private void StartEvent(int index)
    {
        if (index < _events.Length)
        {
            _events[index].Init(_data);
            _events[index].Done += EndEvent;
        }
    }

    private void EndEvent()
    {
        _events[_indexCurrentEvent].Done -= EndEvent;
        _indexCurrentEvent++;        
        StartEvent(_indexCurrentEvent);
    }

    public EventTime GetEvent(string nameEvent)
    {
        EventTime @event = null;
        foreach (EventTime eventTime in _events)
            if (eventTime.Name == nameEvent) @event = eventTime;

        return @event;
    }
}
