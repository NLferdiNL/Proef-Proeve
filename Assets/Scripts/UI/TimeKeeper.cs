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

    // Use this for initialization
    void Start()
    {
        if (!_timeTextField)
        {
            Debug.Log("... Well Shit its not there");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _startTime -= Time.deltaTime;

        if (_startTime < 50)
        {

        }
        else if (_startTime < 15)
        {

        }
    }
}
