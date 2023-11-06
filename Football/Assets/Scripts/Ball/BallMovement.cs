using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class BallMovement : MonoBehaviour
    {

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }



        public void Move()
        {

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider is EdgeCollider2D)
            {
                // You can implement collision response logic here, such as preventing the ball from exiting.

                // For example, to stop the ball from moving further in the direction of the collision:
                _rigidbody.velocity = _rigidbody.velocity / 2;
                
            }
        }

    }

}

