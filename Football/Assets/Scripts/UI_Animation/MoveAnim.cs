using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FootBall
{
    public class MoveAnim : MonoBehaviour
    {        
        public Canvas MainCanvas;
        private Vector2 _initialLocalPos;
        private Vector2 _initialAnchoredPos;
        private RectTransform _rectTransform;

        private Vector2 _canvasSize;
        private Vector2 _referenceResolution;


        private void Awake()
        {            
            _rectTransform = GetComponent<RectTransform>();
            _initialLocalPos = _rectTransform.localPosition;
            _initialAnchoredPos = _rectTransform.anchoredPosition;

            _canvasSize = MainCanvas.GetComponent<RectTransform>().sizeDelta;
            _referenceResolution = MainCanvas.gameObject.GetComponent<CanvasScaler>().referenceResolution;
            
        }
        


        public void MoveOutTop(float duration)
        {
            gameObject.GetComponent<RectTransform>().DOAnchorPosY(gameObject.GetComponent<RectTransform>().sizeDelta.y / 2, duration);          
        }


        public void MoveOutBottom(float duration)
        {
            gameObject.GetComponent<RectTransform>().DOAnchorPosY(-_rectTransform.sizeDelta.y/2, duration);
        }


        public void MoveOutRight(float duration)
        {
            _rectTransform.DOAnchorPosX(_referenceResolution.x / 2 + _rectTransform.sizeDelta.x, duration);                                  
        }


        public void MoveOutLeft(float duration)
        {
            _rectTransform.DOAnchorPosX(-_referenceResolution.x / 2 - _rectTransform.sizeDelta.x, duration);
        }


        public void MoveToInitialLocalPos(float duration)
        {
            _rectTransform.DOAnchorPos(_initialLocalPos, duration);
        }


        public void MoveToInitialAnchoredPos(float duration)
        {
            _rectTransform.DOAnchorPos(_initialAnchoredPos, duration);
        }


        public void ChangeScale(float newScale, float duration)
        {
            _rectTransform.DOScale(newScale, duration)
                .SetEase(Ease.InQuad/*OutElastic*/);            
        }



    }
}
