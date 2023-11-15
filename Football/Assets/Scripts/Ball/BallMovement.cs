using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField]
        private IntReference _teamOneScore;
        [SerializeField]
        private IntReference _teamTwoScore;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }


        public void MakeGoal()
        {
            if (transform.position.x > 0)
            {
                _teamOneScore.Value++;
                Debug.Log("_teamOneScore");
            }
            else
            {
                _teamTwoScore.Value++;
                Debug.Log("_teamTwoScore");
            }

            StopBall();
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


        public void ReturnToCenter()
        {
            gameObject.transform.position = new Vector2(0, 0);
        }


        void StopBall()
        {
            // Ballni harakatdan to'xtatadi.
        }


    }

}

