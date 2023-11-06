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
                
        private float _initialDrag;
        private float _minimalSpeed = 0.35f;

        #region MonoBehaviour CallBacks
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _dragHandler = GetComponent<DragHandler>();
            _arrowLineRenderer = transform.GetChild(2).transform.GetComponent<ArrowLineRenderer>();

            _initialDrag = _rigidbody2D.drag; // F++
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
                ChangePlayerDrag();
                StartCoroutine(CheckVelocity());                
            }
        }
        
        public bool IsBallUnMove()
        {
            if (_rigidbody2D.velocity == Vector2.zero)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
       

        IEnumerator CheckVelocity()
        {
            yield return new WaitForSeconds(0.5f);
            if (IsBallUnMove())
            {                
                GameManager.Instance.UpdateGameState(GameState.Idle);
                _rigidbody2D.drag = _initialDrag;
            }
        }

        

        void ChangePlayerDrag()
        {
            Vector3 velocity = _rigidbody2D.velocity;
            float speed = velocity.magnitude;
            
            if (speed < _minimalSpeed && speed != 0)
            {
                _rigidbody2D.drag += 1f;
                //Debug.Log("_rigidbody2D.drag = " + _rigidbody2D.drag);
            }
            //else if (speed == 0)
            //{
            //    _rigidbody2D.drag = _initialDrag;
            //}
            
        }

        #endregion

    }

}

