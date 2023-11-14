using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{





    private void OnTriggerEnter2D(Collider2D collision)
    {        
        Ball ball = collision.GetComponent<Ball>();
        if (ball != null)
        {
            ball.MakeGoal();
        }
    }


    

}
