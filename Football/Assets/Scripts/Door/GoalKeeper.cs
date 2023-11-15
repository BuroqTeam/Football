using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    /// <summary>
    /// Door ning qaysi biriga gol urilganini tekshiruvchi script.
    /// </summary>
    public class GoalKeeper : MonoBehaviour
    {
        #region Fields
        //[SerializeField] private GoalAction _goalAction;
        //public enum DoorState { Left, Right};
        //public DoorState CurrentState;
        //public GameEvent PlayerDoorCollisionSO;
        //public GameEvent BallDoorCollisionSO;
        #endregion


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                collision.GetComponent<BallMovement>().MakeGoal();
                Debug.Log("Ishladi");
            }

            //Ball ball = collision.GetComponent<Ball>();
            //if (ball != null)
            //{
            //    ball.MakeGoal();
            //}            
        }

                

    }
}
