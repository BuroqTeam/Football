using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class DoorCollision : MonoBehaviour
    {
        #region Fields
        public enum DoorState { Left, Right};
        public DoorState CurrentState;

        public GameEvent PlayerDoorCollisionSO;
        public GameEvent BallDoorCollisionSO;
        #endregion


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) 
            {
                Debug.Log("Return Player initial pos");
            }
            else if (collision.gameObject.CompareTag("Ball"))
            {
                CheckDoor();
                Debug.Log("Goal");
            }
        }


        #region Methods
        void CheckDoor()
        {

        }
        #endregion

    }
}
