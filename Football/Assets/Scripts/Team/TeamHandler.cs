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

        public float timer = 0f;
        float interval = 15f;

        private void Awake()
        {
            CreatePlayers(FirstTeamSO, _firstPlayers, PlayerPrefab);
            CreatePlayers(SecondTeamSO, _secondPlayers, PlayerPrefabOther);
        }

        private void Start()
        {
            SwitchTurn();
        }
                

        private void FixedUpdate()
        {
            //if (GameManager.Instance.CurrentState.Equals(GameState.Idle))
            //{
            //    timer += Time.deltaTime;

            //    if (timer >= interval)
            //    {
            //        SwitchTurn();

            //        timer = 0f;
            //    }
            //}
            //else
            //{
            //    timer = 0;
            //}
        }


        void CreatePlayers(TeamPosition team, List<GameObject> players, GameObject prefab)
        {
            foreach (Vector2 pos in team.PlayerPositions)
            {
                GameObject player = Instantiate(prefab);
                player.GetComponent<PlayerMovement>().TeamHand = this;
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
            Debug.Log("Switch Turn");
        }

        void EnablePlayers(List<GameObject> players, bool val)
        {
            foreach (GameObject player in players)
            {
                player.GetComponent<Player>().IsEnable = val;
            }
        }


        public void PlayerChecker()
        {
            int numFirst = 0;
            int numSecond = 0;

            for (int i = 0; i < _firstPlayers.Count; i++)
            {
                if (!_firstPlayers[i].GetComponent<PlayerMovement>().IsPlayerMoving)                
                    numFirst++;                
                else
                {
                    break;
                }
            }

            for (int i = 0; i < _secondPlayers.Count; i++)
            {
                if (!_secondPlayers[i].GetComponent<PlayerMovement>().IsPlayerMoving)                
                    numSecond++;                
                else
                {
                    break;
                }
            }

            if (numFirst == _firstPlayers.Count && numSecond == _secondPlayers.Count)
            {                
                GameManager.Instance.UpdateGameState(GameState.Idle);
                SwitchTurn();
                timer = 0;
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

