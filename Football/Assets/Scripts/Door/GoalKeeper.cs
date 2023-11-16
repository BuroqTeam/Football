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
        public GameEvent GoalEvent;
        //[SerializeField] private GoalAction _goalAction;
        //public enum DoorState { Left, Right};
        //public DoorState CurrentState;
        //public GameEvent PlayerDoorCollisionSO;
        //public GameEvent BallDoorCollisionSO;
        #endregion


        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log(collision.name + " " + collision.isTrigger);
            if (collision.gameObject.CompareTag("Ball"))
            {
                if (collision.GetType() == typeof(BoxCollider2D))
                {
                    collision.GetComponent<BallMovement>().MakeGoal();
                    GoalEvent.Raise();
                }
            }
            else if (collision.CompareTag("Player"))
            {
                // Out player from GoalKeeper area.
            }
                       
        }

                

    }
}
