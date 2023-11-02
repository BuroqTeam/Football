using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FootBall
{
    public class PlayerMovement : MonoBehaviour
    {        
        private Rigidbody2D _rigidbody2D;
        private DragHandler _dragHandler;
        private ArrowLineRenderer _arrowLineRenderer;



        #region MonoBehaviour CallBacks
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _dragHandler = GetComponent<DragHandler>();
            _arrowLineRenderer = transform.GetChild(2).transform.GetComponent<ArrowLineRenderer>();
        }

        private void FixedUpdate()
        {
            KickBall();
        }
        #endregion


        #region Methods
        void KickBall()
        {
            if (GameManager.Instance.CurrentState.Equals(GameState.BallMoving))
            {
                _rigidbody2D.AddForce(_arrowLineRenderer.GetDirection() * _dragHandler.LengthOfMouseDrag * 1000);
                StartCoroutine(CheckVelocity());
            }
        }

        IEnumerator CheckVelocity()
        {
            yield return new WaitForSeconds(0.5f);
            if (_rigidbody2D.velocity.Equals(Vector2.zero))
            {
                Debug.Log("Not Move");
                GameManager.Instance.UpdateGameState(GameState.Idle);
            }
        }
        #endregion

    }

}

