using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class PlayerCollision : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Vector3 _lastVelocity;


        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            _lastVelocity = _rigidbody2D.velocity;
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Line" || collision.gameObject.name == "Line_Test")
            {
                var speed = _lastVelocity.magnitude;
                var direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
                _rigidbody2D.velocity = direction * Mathf.Max(speed, 0);
            }
        }
    }
}
