using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;
    public GameEvent StartSO;

    public static event Action<GameState> OnGameStateChanged;

    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.Targeting);
        
    }


    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Start:
                StartSO.Raise();
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
        OnGameStateChanged?.Invoke(newState);
    }

   





}


