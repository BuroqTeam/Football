using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FootBall
{
    public class MoveAnim : MonoBehaviour
    {
        public enum Movestate {NoOne, Horizontal, Vertical };
        public Movestate CurrentState;
        public Canvas MainCanvas;
        [HideInInspector] public Vector3 InitialPos;
        private RectTransform _rectTransform;

        private Vector2 _canvasSize;
        private Vector2 _referenceResolution;

        private void Awake()
        {            
            _rectTransform = GetComponent<RectTransform>();
            InitialPos = _rectTransform.localPosition;
            _canvasSize = MainCanvas.GetComponent<RectTransform>().sizeDelta;
            _referenceResolution = MainCanvas.gameObject.GetComponent<CanvasScaler>().referenceResolution;

            //SetPosition();
        }

        
        void SetPosition()
        {
            switch (CurrentState)
            {
                case Movestate.NoOne:
                    break;
                case Movestate.Horizontal:
                    MoveOutLeftAndRight();
                    break;
                case Movestate.Vertical:
                    MoveOutToUp();
                    break;
            }
        }


        public void MoveOutToUp()
        {
            
            gameObject.GetComponent<RectTransform>().DOAnchorPosY(gameObject.GetComponent<RectTransform>().sizeDelta.y, 0.1f);
        }


        void MoveOutLeftAndRight()
        {
            if (transform.position.x > 0) {
                _rectTransform.localPosition = new Vector3(_referenceResolution.x / 2 +_rectTransform.sizeDelta.x, InitialPos.y, InitialPos.z);
            }
            else if (transform.position.x < 0)
            {
                _rectTransform.localPosition = new Vector3(-_canvasSize.y / 2, InitialPos.y, InitialPos.z);
            }
        }


        public void MoveCenter(float durration)
        {
            _rectTransform.DOAnchorPos(InitialPos, durration);
        }



    }
}
