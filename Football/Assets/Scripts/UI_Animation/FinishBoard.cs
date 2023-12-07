using DG.Tweening;
using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FootBall
{
    public class FinishBoard : MonoBehaviour
    {
        public GameObject Buttons;
        public GameObject TopTablo;
        public GameObject FinishPanel;
        public GameObject BlurFinishPanel;
        private GameObject _finishBoard;
        
        public TMP_Text ScoreOfTeams;
        [SerializeField]
        private IntReference _teamOneScore;
        [SerializeField]
        private IntReference _teamTwoScore;


        void Start()
        {
            _finishBoard = gameObject;
        }

                
        private void OnEnable()
        {
            //Debug.Log("Object is enable true");
            WriteScore();
            SwitchObjects();
        }


        void WriteScore()
        {
            ScoreOfTeams.text = _teamOneScore.Value.ToString() + " : " + _teamTwoScore.Value.ToString();
        }


        void SwitchObjects()
        {
            Buttons.SetActive(false);
            TopTablo.SetActive(false);
            FinishPanel.SetActive(true);
            BlurFinishPanel.SetActive(true);
        }

    }
}
