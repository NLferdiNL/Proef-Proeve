using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour
{

    //public delegate void MyTimeKeeper(float CurrentTimer);
    //public static event MyTimeKeeper myTimeKeeper;

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
            Debug.Log("... Well Shit its not there");
        }
        _currentTime = _startTime;
    }

    void Update()
    {
        _currentTime -= Time.deltaTime;
        UpdateTimeText();

        if (_currentTime < _NormalPhase && _currentTime > _WarningPhase)
        {
            Debug.Log("all is good man plenty of time to go around: " + _currentTime);
            //myTimeKeeper(_NormalPhase);
        }
        else if (_currentTime < _WarningPhase && _currentTime > _DangerPhase)
        {
            Debug.Log("ohhhh u runnin out of time bud: " + _currentTime);
            //myTimeKeeper(_WarningPhase);
        }
        else if (_currentTime < _DangerPhase && _currentTime > _EndPhase)
        {
            Debug.Log("Good luck fam u got like 15 secconds: " + _currentTime);
            //myTimeKeeper(_DangerPhase);
        }
        else if (_currentTime <= _EndPhase)
        {
            //myTimeKeeper(_EndPhase);
            Debug.Log("AAAND UR OUT!!! : " + _currentTime);
            SceneManager.LoadScene("MainMenu");//needs to be changed
        }
    }

    private void UpdateTimeText()
    {
        _timeTextField.text = "Time:    " + _currentTime.ToString("#.00");
    }
}
