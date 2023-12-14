using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FootBall
{
    /// <summary>
    /// This script responsible logo and text change in Football scene after Team selection.
    /// This script added gameObjects which has component Image or TMP_Text. 
    /// </summary>
    public class PrintTeamData : MonoBehaviour
    {
        public enum Teams {NoOne, FirstTeam, SecondTeam }
        public Teams CurrentTeam;
        public enum Changes {Nothing, Text, Sprite}
        public Changes CurrentChange;

        public TeamListSO TeamList;

        private string _currentTeamName;
        private Sprite _currentTeamLogo;


        private void Awake()
        {
            FindLogoAndName();
        }

        
        void FindLogoAndName()
        {
            if (CurrentTeam == Teams.FirstTeam) 
            {
                _currentTeamName = PlayerPrefs.GetString("FirstTeamName");
            }
            else if (CurrentTeam == Teams.SecondTeam)
            {
                _currentTeamName = PlayerPrefs.GetString("SecondTeamName");
            }


            for (int i = 0; i < TeamList.TeamNames.Length; i++)
            {
                if (_currentTeamName == TeamList.TeamNames[i])
                {
                    _currentTeamLogo = TeamList.TeamLogos[i];
                    break;
                }
            }

            WriteLogoAndName();
        }


        void WriteLogoAndName()
        {
            if (CurrentChange == Changes.Text)
            {
                gameObject.GetComponent<TMP_Text>().text = _currentTeamName;
            }
            else if (CurrentChange == Changes.Sprite)
            {
                gameObject.GetComponent<Image>().sprite = _currentTeamLogo;
            }
        }


    }
}
