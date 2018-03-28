using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour
{

    public delegate void MyTimeKeeper(float CurrentTimer);
    public static event MyTimeKeeper myTimeKeeper;

    [SerializeField]
    private Text _timeTextField;

    [SerializeField]
    private float _startTime = 100.5f;
    [SerializeField]
    private float _currentTime;


    private float _NormalPhase = 100;
    private float _WarningPhase = 50;
    private float _DangerPhase = 15;
    private float _EndPhase = 0;

    void Start()
    {
        if (!_timeTextField)
        {
            print("... Well Shit its not there");
        }
        _currentTime = _startTime;
    }

    void Update()
    {
        _currentTime -= Time.deltaTime;
        UpdateTimeText();

        if (_currentTime < _NormalPhase && _currentTime > _WarningPhase)
        {
            if (myTimeKeeper != null)
                myTimeKeeper(_NormalPhase);
        }
        else if (_currentTime < _WarningPhase && _currentTime > _DangerPhase)
        {
            if (myTimeKeeper != null)
                myTimeKeeper(_WarningPhase);
        }
        else if (_currentTime < _DangerPhase && _currentTime > _EndPhase)
        {
            if (myTimeKeeper != null)
                myTimeKeeper(_DangerPhase);
        }
        else if (_currentTime <= _EndPhase)
        {
            if (myTimeKeeper != null)
                myTimeKeeper(_EndPhase);
        }
    }

    private void UpdateTimeText()
    {
        _timeTextField.text = "Time:    " + _currentTime.ToString("#.00");
    }
}
