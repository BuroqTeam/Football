using DG.Tweening;
using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FootBall
{
    public class TeamHandler : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        public GameObject PlayerPrefabOther;
        public StrategyList FirstTeamStrategy;
        public StrategyList SecondTeamStrategy;
        [HideInInspector] public TeamPosition FirstTeamSO;
        [HideInInspector] public TeamPosition SecondTeamSO;

        [HideInInspector] public List<GameObject> _firstPlayers = new List<GameObject>();
        [HideInInspector] public List<GameObject> _secondPlayers = new List<GameObject>();

        private int _turn = 0;
        [SerializeField] private TMP_Text _rightTeamText;
        [SerializeField] private TMP_Text _leftTeamText;

        float timer = 0f;
        float interval = 15f;
        float zPos = -0.1f;

        public IntVariable SniperValue;
        public BoolVariable StartAnimFinished;
        private Vector2 _initialPosRightTeam = new Vector2(3, -6);
        private Vector2 _initialPosLeftTeam = new Vector2(-3, -6);
        private bool _isPlayersOnPosition = false;

        public GameEvent GameStartEvent;
        public BoolVariable TimeIsFinish;
        public BoolVariable IsGoalHappened;


        private void Awake()
        {
            int firstTeamStrategy = PlayerPrefs.GetInt("FirstTeamStrategyIndex");
            FirstTeamSO = FirstTeamStrategy.ListOfTeamPositions[firstTeamStrategy];

            int secondTeamStrategy = PlayerPrefs.GetInt("SecondTeamStrategyIndex");
            SecondTeamSO = SecondTeamStrategy.ListOfTeamPositions[secondTeamStrategy];
        }


        private void Start()
        {
            TimeIsFinish.Value = false;
            SniperValue.Value = 0;
            //SwitchTurn();
        }
        

        private void FixedUpdate()
        {
            if (StartAnimFinished.Value)
            {
                StartAnimFinished.Value = false;                
                SwitchTurn();
            }

            if (GameManager.Instance.CurrentState.Equals(GameState.Idle) && _isPlayersOnPosition && !TimeIsFinish.Value && !IsGoalHappened.Value)
            {
                timer += Time.deltaTime;                

                int minutes = Mathf.FloorToInt(timer / 60);
                int seconds = (int)interval - Mathf.FloorToInt(timer % 60);

                if (_turn % 2 != 0)
                {
                    _leftTeamText.text = "00:00";
                    _rightTeamText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                }
                else
                {                    
                    _rightTeamText.text = "00:00";
                    _leftTeamText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                }

                if (timer >= interval)
                {
                    SwitchTurn();
                    timer = 0f;
                    Debug.Log("Switch Turn");
                }
            }
            else
            {
                timer = 0;
                _leftTeamText.text = "00:00";
                _rightTeamText.text = "00:00";
            }
        }


        /// <summary>
        /// This script called in TeamCreateEvent which located in BoardAnimation script.
        /// </summary>
        public void CreateTeam()
        {
            StartCoroutine(CreatePlayers(FirstTeamSO, _firstPlayers, PlayerPrefab, _initialPosRightTeam));
            StartCoroutine(CreatePlayers(SecondTeamSO, _secondPlayers, PlayerPrefabOther, _initialPosLeftTeam));
        }


        IEnumerator CreatePlayers(TeamPosition team, List<GameObject> players, GameObject prefab, Vector2 initialPos)
        {
            int playerNumber = 1;
            foreach (Vector2 pos in team.PlayerPositions)
            {
                GameObject player = Instantiate(prefab);
                player.GetComponent<PlayerMovement>().TeamHand = this;
                player.GetComponent<Player>().PlayerNumber = playerNumber;
                playerNumber += 1;
                //player.transform.position = new Vector3(pos.x, pos.y, zPos);
                player.transform.position = new Vector3(initialPos.x, initialPos.y, zPos);
                player.transform.DOMove(new Vector3(initialPos.x, -3, zPos), 0.3f);
                yield return new WaitForSeconds(0.3f);
                player.transform.DOMove(new Vector3(pos.x, pos.y, zPos), 0.3f);
                players.Add(player);
                //yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.5f);

            //MoveAnimEvent.Invoke();
            GameStartEvent.Raise();
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

            _isPlayersOnPosition = true;
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
                Vector3 resetPos = teamPosition.PlayerPositions[i];
                listOfObject[i].transform.position = new Vector3(resetPos.x, resetPos.y, zPos)/*teamPosition.PlayerPositions[i]*/;
            }
        }

        
        public void IncreaseSniperValue(Image enabledImage)
        {
            SniperValue.Value += 1;
            if (enabledImage.enabled) 
            {
                enabledImage.enabled = false;
            }
            else if (!enabledImage.enabled)
            {
                enabledImage.enabled = true;
            }
        }


    }

}

