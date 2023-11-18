using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FootBall
{
    public class TimeController : MonoBehaviour
    {
        #region Fields
        [SerializeField] private TMP_Text _countDownText;
        private float _countDownTime = 180;
        #endregion


        #region MonoBehaviour CallBacks
        private void Update()
        {
            CountDown();
        }
        #endregion


        #region Methods
        void CountDown()
        {
            if (_countDownTime > 0) { 
                _countDownTime -= Time.deltaTime;
            }
            else if (_countDownTime < 0)
            {
                _countDownTime = 0;
                Debug.Log("Game finished");
            }

            int minutes = Mathf.FloorToInt(_countDownTime / 60);
            int seconds = Mathf.FloorToInt(_countDownTime % 60);

            _countDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        #endregion

    }

}

