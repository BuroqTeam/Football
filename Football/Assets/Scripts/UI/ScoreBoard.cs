using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FootBall
{
    public class ScoreBoard : MonoBehaviour
    {
        //public int LeftTeamScore;
        //public int RightTeamScore;

        [SerializeField]
        private IntReference _teamOneScore;
        [SerializeField]
        private IntReference _teamTwoScore;

        [SerializeField]
        private TMP_Text _score;

        private void Awake()
        {
            _teamOneScore.Value = 0;
            _teamTwoScore.Value = 0;
        }



        private void Update()
        {
            _score.text = _teamOneScore.Value.ToString() + " : " + _teamTwoScore.Value.ToString();
        }


    }
}

