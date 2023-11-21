using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace FootBall
{
    public class GoalKeeperSpace : MonoBehaviour
    {
        public StringVariable GoalKeeperSO;        
        private SpriteRenderer _rightKeeper;
        private SpriteRenderer _leftKeeper;

        void Start()
        {
            GoalKeeperSO.Value = "null";
            _rightKeeper = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            _leftKeeper = gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();            
        }


        void Update()
        {
            GoalKeeperArea();
        }


        void GoalKeeperArea()
        {
            if (GoalKeeperSO.Value == "null" || GameManager.Instance.CurrentState.Equals(GameState.BallMoving))
            {
                GoalKeeperSO.Value = "null";
                _rightKeeper.enabled = (false);
                _leftKeeper.enabled = (false);
            }
            else if(GoalKeeperSO.Value != null)
            {
                if (GoalKeeperSO.Value == "right")
                {
                    _rightKeeper.enabled = (true);
                    _leftKeeper.enabled = (false);
                }
                else if (GoalKeeperSO.Value == "left")
                {
                    _rightKeeper.enabled = (false);
                    _leftKeeper.enabled = (true);
                }
            }             
        }


    }
}
