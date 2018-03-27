using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{
    [SerializeField]
    private Text _timeTextField;

    [SerializeField]
    private float _startTime = 100.5f;
    [SerializeField]
    private float _currentTime;

    // Use this for initialization
    void Start()
    {
        if (!_timeTextField)
        {
            Debug.Log("... Well Shit its not there");
        }
        _currentTime = _startTime;
    }

    // Update is called once per frame
    void Update()
    {
        _startTime -= Time.deltaTime;

        UpdateTimeText();
        if (_currentTime < 50)
        {
            Debug.Log("ohhhh u runnin out of time bud");
        }
        else if (_currentTime < 15)
        {
            Debug.Log("Good luck fam u got like 15 secconds");
        }
        else if (_currentTime < 0)
        {
            Debug.Log("AAAND UR OUT!!! ");
        }
    }

    private void UpdateTimeText()
    {
        _timeTextField.text = "Time: " + _currentTime;            
    }
}
