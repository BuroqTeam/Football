using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FootBall
{
    public class Player : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public enum PlayerState {SimplePlayer, GoalKeeperPlayer};
        public PlayerState CurrentState;

        public PlayerInfo PlayerInfoSO;
        private TMP_Text _playerInfo;
        public bool IsEnable;
        [HideInInspector] public bool IsGoalKeeperPlayer;
        [HideInInspector] public int PlayerNumber;

        private void Awake()
        {
            _playerInfo = transform.GetChild(3).GetComponent<TMP_Text>();
            _playerInfo.text = PlayerInfoSO.Name + " " + PlayerInfoSO.Number;
            _playerInfo.GetComponent<MeshRenderer>().sortingOrder = 100;            
        }


        private void Start()
        {
            CheckCurrentState();
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            _playerInfo.enabled = true;
        }
               

        public void OnPointerExit(PointerEventData eventData)
        {
            _playerInfo.enabled = false;
        }
        
        
        void CheckCurrentState()
        {
            if (PlayerNumber == 1) 
            {
                CurrentState = PlayerState.GoalKeeperPlayer;
                IsGoalKeeperPlayer = true;
                gameObject.layer = 3;
            }
            else
            {
                CurrentState = PlayerState.SimplePlayer;
                IsGoalKeeperPlayer = false;
            }


            float xValue = gameObject.transform.position.x;
            //Debug.Log("gameObject.transform.position = " + gameObject.transform.position);

            //if (Mathf.Abs(xValue) > 5 ) 
            //{
            //    CurrentState = PlayerState.GoalKeeperPlayer;
            //    IsGoalKeeperPlayer = true;
            //    gameObject.layer = 3;
            //}
            //else{
            //    CurrentState = PlayerState.SimplePlayer;
            //    IsGoalKeeperPlayer = false;
            //}
        }


    }

}


