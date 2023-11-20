using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FootBall
{
    public class Player : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public enum PlayerState {SimplePlayer, GoalKeeper};
        public PlayerState CurrentState;

        public PlayerInfo PlayerInfoSO;
        private TMP_Text _playerInfo;
        public bool IsEnable;

        private void Awake()
        {
            _playerInfo = transform.GetChild(3).GetComponent<TMP_Text>();
            _playerInfo.text = PlayerInfoSO.Name + " " + PlayerInfoSO.Number;
            _playerInfo.GetComponent<MeshRenderer>().sortingOrder = 100;
        }




        public void OnPointerEnter(PointerEventData eventData)
        {
            _playerInfo.enabled = true;
        }

       

        public void OnPointerExit(PointerEventData eventData)
        {
            _playerInfo.enabled = false;
        }


      

        
    }

}


