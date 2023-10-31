using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public PlayerData PlayerDataSO;
   
   


    // Update is called once per frame
    void Update()
    {
        RotateCircle();


    }

    void RotateCircle()
    {
        if (GameManager.Instance.State.Equals(GameState.Targeting))
        {
            transform.Rotate(PlayerDataSO.RotatingAngle * Time.deltaTime * PlayerDataSO.RotatorSpeed);
        }
    }
}
