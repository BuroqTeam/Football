using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class BallCollision : MonoBehaviour
    {
        public GameEvent BallColisionSO;


        private void OnTriggerEnter2D(Collider2D collision)
        {            
            BallColisionSO.Raise();
            
        }




    }

}


