using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class TeamStrategy : MonoBehaviour
    {
        public enum Teams { NoTeam, FirstTeam, SecondTeam };
        public Teams CurrentTeam;

        public GameObject[] TeamPlayers;
        public TeamPosition[] StrategyPositions;
        public TeamPosition CurrentPosition;

        private int _currentIndex = 0;

        void Start()
        {
            TeamSetPosition(TeamPlayers, CurrentPosition);            
        }

                
        void TeamSetPosition(GameObject[] objArray, TeamPosition teamPosition)
        {
            for (int i = 0; i < objArray.Length; i++)
            {
                objArray[i].transform.localPosition = teamPosition.PlayerPositions[i];
            }

            if(CurrentTeam == Teams.FirstTeam)
            {
                PlayerPrefs.SetInt("FirstTeamStrategyIndex", _currentIndex);
            }
            else if(CurrentTeam == Teams.SecondTeam)
            {
                PlayerPrefs.SetInt("SecondTeamStrategyIndex", _currentIndex);
            }

        }


        public void ChangeStrategy()
        {
            _currentIndex += 1;
            if (_currentIndex == StrategyPositions.Length)
                _currentIndex = 0;

            CurrentPosition = StrategyPositions[_currentIndex];
            TeamSetPosition(TeamPlayers, CurrentPosition);
        }

    }
}
