using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FootBall
{
    public class CircleScaler : MonoBehaviour
    {

        public PlayerData PlayerDataSO;
        private SpriteRenderer _spriteRenderer;


        #region MonoBehaviour CallBacks
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        #endregion

        #region Methods
        public void ScaleCircle(float lengthOfMouseDrag)
        {
            if (lengthOfMouseDrag > 0 && lengthOfMouseDrag <= PlayerDataSO.MaxCircleSize)
            {
                Vector3 temp = transform.localScale;
                temp.x = lengthOfMouseDrag / _spriteRenderer.sprite.bounds.size.x;
                temp.y = lengthOfMouseDrag / _spriteRenderer.sprite.bounds.size.y;
                temp.z = 0;
                transform.localScale = temp;
            }
        }

        public void ResetCircleInitialScale()
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
        #endregion

    }

}

