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


    [SerializeField]
    private float _WarningPhase = 50;
    [SerializeField]
    private float _DangerPhase = 15;
    [SerializeField]
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

        if (myTimeKeeper != null)
        {
            if (_currentTime < _WarningPhase)
            {
                Debug.Log("ohhhh u runnin out of time bud");
                myTimeKeeper(_EndPhase);
            }
            else if (_currentTime < _DangerPhase)
            {
                myTimeKeeper(_DangerPhase);
                Debug.Log("Good luck fam u got like 15 secconds");
            }
            else if (_currentTime < _EndPhase)
            {
                myTimeKeeper(_EndPhase);
                Debug.Log("AAAND UR OUT!!! ");
                SceneManager.LoadScene("MainGame");//needs to be changed
            }
        }
    }

    private void UpdateTimeText()
    {
        _timeTextField.text = "Time: " + _currentTime.ToString("#.00");
    }
}
