using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FootBall
{
    public class GameManager : MonoBehaviour
    {

        #region Fields
        public static GameManager Instance;
        public GameState CurrentState;
        public GameEvent StartSO;
        public GameEvent IdleSO;
        #endregion


        #region MonoBehaviour CallBacks
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            UpdateGameState(GameState.Idle);
        }
        #endregion


        #region Methods
        public void UpdateGameState(GameState newState)
        {
            CurrentState = newState;
            switch (newState)
            {
                case GameState.Start:
                    StartSO.Raise();
                    break;
                case GameState.Idle:
                    IdleSO.Raise();
                    break;
                case GameState.Targeting:
                    break;
                case GameState.BallMoving:
                    break;
                case GameState.Goal:
                    break;
                case GameState.Finish:
                    break;
            }
        }
        #endregion






    }

}



