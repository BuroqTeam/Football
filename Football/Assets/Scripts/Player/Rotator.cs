using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FootBall
{
    public class Rotator : MonoBehaviour
    {

        public PlayerData PlayerDataSO;
        private SpriteRenderer _spriteRenderer;


        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = false;
        }

        void Update()
        {
            RotateCircle();
        }


        void RotateCircle()
        {
            if (GameManager.Instance.CurrentState.Equals(GameState.Idle))
            {
                _spriteRenderer.enabled = true;
                transform.Rotate(PlayerDataSO.RotatingAngle * Time.deltaTime * PlayerDataSO.RotatorSpeed);
            }
            else
            {
                _spriteRenderer.enabled = false;
            }
        }
    }

}

