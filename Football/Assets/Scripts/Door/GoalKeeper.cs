using ScriptableObjectArchitecture;
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
        public BoolVariable IsGoalHappened;   // this will be true when happened goal. 
        #endregion


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                if (collision.GetType() == typeof(BoxCollider2D) && !IsGoalHappened.Value)
                {
                    collision.GetComponent<BallMovement>().MakeGoal();
                    GoalEvent.Raise();
                    IsGoalHappened.Value = true;
                }
            }
            else if (collision.CompareTag("Player"))
            {
                // Out player from GoalKeeper area.
            }
                       
        }

                

    }
}
