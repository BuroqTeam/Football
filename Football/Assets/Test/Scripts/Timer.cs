using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _timerText;

    [SerializeField]
    private FloatReference _maxTimer;
    [SerializeField]
    private FloatReference _currentTimer;
    [SerializeField]
    private bool _countDown;

    private void Awake()
    {
        _currentTimer.Value = _maxTimer.Value;
    }

    private void Update()
    {
        _currentTimer.Value = _countDown ? _currentTimer.Value -= Time.deltaTime : _currentTimer.Value += Time.deltaTime;
        _timerText.text = _currentTimer.Value.ToString("0.");

    }


    public void SwitchTeamKick()
    {
        Debug.Log("Run every changes");
        if (_currentTimer.Value <= 0)
        {
            Debug.Log("Switch Team and Reset _currentTimer");
        }
    }




}
