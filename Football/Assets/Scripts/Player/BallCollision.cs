using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class BallCollision : MonoBehaviour
    {
        public GameEvent BallColisionSO;
        private Vector3 _lastVelocity;


        private void OnTriggerEnter2D(Collider2D collision)
        {            
            BallColisionSO.Raise();
            
        }


        private void FixedUpdate()
        {
            _lastVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Line"))
            {
                var speed = _lastVelocity.magnitude;
                var direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
                gameObject.GetComponent<Rigidbody2D>().velocity = direction * Mathf.Max(speed, 0);
            }
            //else if (collision.gameObject.CompareTag("Door"))
            //{
            //    Debug.Log("Collide with the Door");
            //}
        }

    }

}


