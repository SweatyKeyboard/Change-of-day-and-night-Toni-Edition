using UnityEngine;
using System;

[Serializable]
public class TimeUnit
{
    //������� ����� ��� ���� ����. ��� ���� �� ������ ����� �� ����� ��� ���� ���
    [SerializeField] private TimeUnits _key;
    [SerializeField] private float _defaultValue;

    public event Action Updated;

    private int _currentTime;
    private int _currentValue;

    public TimeUnits Key => _key;
    public float DefaultValue => _defaultValue;
    public int CurrentValue { get => _currentValue; set { _currentValue = value; Updated?.Invoke(); } }

    // ���� XML-�������� ��� ��� �� �����. Count ������� ����� �����
    public void Count(float allTime)
    {
        _currentTime = (int)allTime / (int)_defaultValue;
        if (_currentTime > CurrentValue) CurrentValue++;
    }

    public void Reset() => _currentValue = 0;
}