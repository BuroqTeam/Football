using ScriptableObjectArchitecture;
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
        //private bool _isCountDownWorking = false;
        private bool _isStartWork = false;
        public BoolVariable StartAnimFinished;
        #endregion


        #region MonoBehaviour CallBacks       

        private void Update()
        {
            //if (StartAnimFinished.Value && !_isCountDownWorking)
            //{
            //    StartCoroutine(CountDownStart());
            //    //Debug.Log(2);
            //}

            if (_isStartWork)
            {
                CountDown();
            }
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


        public void StartCountDown()
        {
            StartCoroutine(CountDownStart());
        }


        IEnumerator CountDownStart()
        {
            //_isCountDownWorking = true;
            yield return new WaitForSeconds(1f);
            
            _isStartWork = true;
        }
        #endregion

    }

}

