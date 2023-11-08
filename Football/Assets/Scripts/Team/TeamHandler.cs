using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class TeamHandler : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        public GameObject PlayerPrefabOther;
        public TeamPosition FirstTeamSO;
        public TeamPosition SecondTeamSO;

        private List<GameObject> _firstPlayers = new List<GameObject>();
        private List<GameObject> _secondPlayers = new List<GameObject>();

        private int _turn;



        private void Awake()
        {
            CreatePlayers(FirstTeamSO, _firstPlayers, PlayerPrefab);
            CreatePlayers(SecondTeamSO, _secondPlayers, PlayerPrefabOther);
        }

        private void Start()
        {
            SwitchTurn();
        }


        void CreatePlayers(TeamPosition team, List<GameObject> players, GameObject prefab)
        {
            foreach (Vector2 pos in team.PlayerPositions)
            {
                GameObject player = Instantiate(prefab);
                player.transform.position = new Vector3(pos.x, pos.y, 0);
                players.Add(player);
            }           
        }


        public void SwitchTurn()
        {
            _turn++;
            if (_turn % 2 != 0)
            {
                EnablePlayers(_firstPlayers, true);
                EnablePlayers(_secondPlayers, false);
            }
            else
            {
                EnablePlayers(_firstPlayers, false);
                EnablePlayers(_secondPlayers, true);

            }
        }

        void EnablePlayers(List<GameObject> players, bool val)
        {
            foreach (GameObject player in players)
            {
                player.GetComponent<Player>().IsEnable = val;
            }
        }


        public void ResetTeamPos() // Call after goal. 
        {
            ResetPlayerPos(_firstPlayers, FirstTeamSO);
            ResetPlayerPos(_secondPlayers, SecondTeamSO);
        }
        

        void ResetPlayerPos(List<GameObject> listOfObject, TeamPosition teamPosition) // Reset all players pos.
        {
            for (int i = 0; i < listOfObject.Count; i++)
            {
                listOfObject[i].transform.position = teamPosition.PlayerPositions[i];
            }
        }


    }

}

