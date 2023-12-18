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
        [SerializeField] private List<SpriteRenderer> _playersUniforms;
        public TeamListSO TeamsDataSo;
        public StrategyList TeamStrategies;        
        [HideInInspector] public TeamPosition CurrentPosition;

        private int _currentStrategyIndex = 0;
        private int _indexOfUniforms = 0;


        void Start()
        {
            CurrentPosition = TeamStrategies.ListOfTeamPositions[0];

            TeamSetPosition(TeamPlayers, CurrentPosition);
            GetPlayerUniforms();
        }

        
        void TeamSetPosition(GameObject[] objArray, TeamPosition teamPosition)
        {
            for (int i = 0; i < objArray.Length; i++)
            {
                objArray[i].transform.localPosition = teamPosition.PlayerPositions[i];
            }

            if(CurrentTeam == Teams.FirstTeam)
            {
                PlayerPrefs.SetInt("FirstTeamStrategyIndex", _currentStrategyIndex);
            }
            else if(CurrentTeam == Teams.SecondTeam)
            {
                PlayerPrefs.SetInt("SecondTeamStrategyIndex", _currentStrategyIndex);
            }

        }

        
        public void ChangeStrategyToRight()
        {
            _currentStrategyIndex += 1;
            if (_currentStrategyIndex == /*StrategyPositions*/TeamStrategies.ListOfTeamPositions.Length)
                _currentStrategyIndex = 0;

            CurrentPosition = /*StrategyPositions*/TeamStrategies.ListOfTeamPositions[_currentStrategyIndex];
            TeamSetPosition(TeamPlayers, CurrentPosition);
        }


        public void ChangeStrategyToLeft()
        {
            _currentStrategyIndex -= 1;
            if (_currentStrategyIndex < 0)
                _currentStrategyIndex = /*StrategyPositions*/TeamStrategies.ListOfTeamPositions.Length - 1;

            CurrentPosition = /*StrategyPositions*/TeamStrategies.ListOfTeamPositions[_currentStrategyIndex];
            TeamSetPosition(TeamPlayers, CurrentPosition);
        }


        public void GetPlayerUniforms()
        {
            for(int i = 0;i < TeamPlayers.Length;i++) 
            {                
                GameObject uniformObject = TeamPlayers[i].transform.GetChild(6).transform.GetChild(1).gameObject;

                if (uniformObject.name == "Uniform")
                    _playersUniforms.Add(uniformObject.GetComponent<SpriteRenderer>());
                else
                    Debug.Log("Human gameObject order is wrong");
            }

            ChangeTeamUniforms();
        }

        
        public void ChangeTeamUniforms()
        {
            //Debug.Log(" _playersUniforms.Count = " + _playersUniforms.Count);

            if (CurrentTeam == Teams.FirstTeam)            
                _indexOfUniforms = PlayerPrefs.GetInt("FirstTeamIndex");            
            else if (CurrentTeam == Teams.SecondTeam)            
                _indexOfUniforms = PlayerPrefs.GetInt("SecondTeamIndex");
            
            Sprite uniformSprite = TeamsDataSo.TeamUniforms[_indexOfUniforms];
            Sprite goalKeeperUniformSprite = TeamsDataSo.GoalKeeperUniforms[_indexOfUniforms];

            for (int i = 0; i < _playersUniforms.Count; i++)  
            {
                if (i == 0)
                {
                    _playersUniforms[i].sprite = goalKeeperUniformSprite;
                    //Debug.Log("Goal Keeper");
                }
                else
                {
                    _playersUniforms[i].sprite = uniformSprite;
                    //Debug.Log("Simple Player");
                }
            }
        }

    }
}
