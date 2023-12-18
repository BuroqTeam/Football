using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FootBall
{
    /// <summary>
    /// This script used in Team Selection scene for change selected football club.
    /// </summary>
    public class TeamChooser : MonoBehaviour
    {
        public enum Teams { NoOne, FirstTeam, SecondTeam}
        public Teams CurrentTeam;

        public TeamListSO TeamList;

        [SerializeField] private TMP_Text TeamName;
        [SerializeField] private Image TeamLogo;
        private int _initialIndex = 0;

        public StringVariable ChosenTeamName;
        public StringVariable EnemyTeamName;

        public UnityEvent UniformChangeEvent;


        private void Awake()
        {
            InitialTeamSet();
        }
        
        
        void InitialTeamSet()
        {            
            while (ChosenTeamName.Value != EnemyTeamName.Value)
            {
                if (CheckTeam())
                {
                    break;
                }
                else
                {
                    _initialIndex += 1;
                }
            }
            
            //Debug.Log(gameObject.name);
            WriteAndSaveData();
        }
        

        public void ChangeTeamToRight()
        {
            while (true)
            {
                //Debug.Log("Working");
                _initialIndex += 1;
                if (_initialIndex < TeamList.TeamNames.Length && CheckTeam())
                {
                    break;
                }
                else if (_initialIndex >= TeamList.TeamNames.Length)
                {
                    _initialIndex = -1;
                }
            }

            
            WriteAndSaveData();
        }
        

        public void ChangeTeamToLeft()
        {
            while (true)
            {
                //Debug.Log("Running");
                _initialIndex -= 1;
                if (_initialIndex >= 0 && CheckTeam())
                {
                    break;
                }
                else if (_initialIndex < 0)
                {
                    _initialIndex = TeamList.TeamNames.Length;
                }
            }

            
            WriteAndSaveData();
        }


        bool CheckTeam()
        {
            if (TeamList.TeamNames[_initialIndex] != EnemyTeamName.Value)            
                return true;
            else
                return false;
        }              


        /// <summary>
        /// This method write FC name on TMP_Text and change club logo. After this save chosen club name on PlayerPrefs
        /// </summary>
        void WriteAndSaveData()
        {
            TeamName.text = TeamList.TeamNames[_initialIndex];
            TeamLogo.sprite = TeamList.TeamLogos[_initialIndex];
            ChosenTeamName.Value = TeamList.TeamNames[_initialIndex];

            if (CurrentTeam == Teams.FirstTeam)
            {
                PlayerPrefs.SetString("FirstTeamName", ChosenTeamName.Value);
                PlayerPrefs.SetInt("FirstTeamIndex", _initialIndex);
                //Debug.Log("FirstTeamName = " + _initialIndex);
            }
            else if(CurrentTeam == Teams.SecondTeam)
            {
                PlayerPrefs.SetString("SecondTeamName", ChosenTeamName.Value);
                PlayerPrefs.SetInt("SecondTeamIndex", _initialIndex);
                //Debug.Log("SecondTeamName = " + _initialIndex);
            }

            //Debug.Log("11");
            UniformChangeEvent.Invoke();
        }

        /*
        public void ChangeTeamToRight()
        {
            _initialIndex++;

            if (_initialIndex < TeamList.TeamNames.Count())
            {
                TeamName.text = TeamList.TeamNames[_initialIndex];
                TeamLogo.sprite = TeamList.TeamLogos[_initialIndex];
            }
            else
            {
                _initialIndex = 0;
                TeamName.text = TeamList.TeamNames[_initialIndex];
                TeamLogo.sprite = TeamList.TeamLogos[_initialIndex];
            }
            ChosenTeamName.Value = TeamList.TeamNames[_initialIndex];
        }


        public void ChangeTeamToLeft()
        {
            _initialIndex--;

            if (_initialIndex >= 0)
            {
                TeamName.text = TeamList.TeamNames[_initialIndex];
                TeamLogo.sprite = TeamList.TeamLogos[_initialIndex];
            }
            else
            {
                _initialIndex = TeamList.TeamNames.Count() - 1;
                TeamName.text = TeamList.TeamNames[_initialIndex];
                TeamLogo.sprite = TeamList.TeamLogos[_initialIndex];
            }
            ChosenTeamName.Value = TeamList.TeamNames[_initialIndex];
        }         
         */
    }
}
