using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FootBall
{
    public class GameButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public Vector3 RotationAngle;
        public float RotatorSpeed;


        public UnityEvent OnPointerEnterEvent;

        Image _buttonImage;
        Transform _iconTransform;
        bool _isOnPointerEnter;

        private void Awake()
        {
            _buttonImage = transform.GetChild(0).GetComponent<Image>();
            _iconTransform = transform.GetChild(1);
        }




        public void OnPointerEnter(PointerEventData eventData)
        {
            _isOnPointerEnter = true;
            _buttonImage.gameObject.SetActive(true);
            OnPointerEnterEvent.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isOnPointerEnter = false;
            _buttonImage.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_isOnPointerEnter)
            {
                _iconTransform.Rotate(RotationAngle * Time.deltaTime * RotatorSpeed);
            }
            
        }




    }
}

