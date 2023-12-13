using ScriptableObjectArchitecture;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FootBall
{
    public class TeamChooser : MonoBehaviour
    {
        public TeamListSO TeamList;

        [SerializeField] private TMP_Text TeamName;
        [SerializeField] private Image TeamLogo;
        [SerializeField] private int _initialIndex = 0;

        public StringVariable ChosenTeamName;
        public StringVariable EnemyTeamName;

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

            
            Debug.Log(gameObject.name);
            TeamName.text = TeamList.TeamNames[_initialIndex];
            TeamLogo.sprite = TeamList.TeamLogos[_initialIndex];
            ChosenTeamName.Value = TeamList.TeamNames[_initialIndex];
        }


        public void ChangeTeamToRight()
        {
            _initialIndex++;

            if (_initialIndex < TeamList.TeamNames.Count())
            {
                //while (ChosenTeamName.Value != EnemyTeamName.Value)
                //if (CheckTeam())
                //        break;
                //    else
                //        _initialIndex += 1;

                TeamName.text = TeamList.TeamNames[_initialIndex];
                TeamLogo.sprite = TeamList.TeamLogos[_initialIndex];
            }
            else
            {
                _initialIndex = 0;

                //while (ChosenTeamName.Value != EnemyTeamName.Value)
                //    if (CheckTeam())
                //        break;
                //    else
                //        _initialIndex += 1;

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


        bool CheckTeam()
        {
            if (TeamList.TeamNames[_initialIndex] != EnemyTeamName.Value)            
                return true;            
            else            
                return false;            
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
        }         
         */
    }
}
