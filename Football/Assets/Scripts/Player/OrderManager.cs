using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FootBall
{
    /// <summary>
    /// This script is responsible for order of player and his childs (Which has Renderer component)
    /// </summary>
    public class OrderManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Header("Initial orders")]
        [SerializeField] private SpriteRenderer _playerRenderer;
        [SerializeField] private SpriteRenderer _edgeRenderer;
        [SerializeField] private SpriteRenderer _circleRenderer;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private SpriteRenderer _arrowRenderer;
        [SerializeField] private LineRenderer _sniperRenderer;

        
        private int _initialOrderOfPlayer;
        private int _initialOrderOfEdge;
        private int _initialOrderOfCircle;
        private int _initialOrderOfLine;
        private int _initialOrderOfArrow;
        private int _initialOrderOfSniper;


        void Start()
        {
            _initialOrderOfPlayer = _playerRenderer.sortingOrder;
            _initialOrderOfEdge = _edgeRenderer.sortingOrder;
            _initialOrderOfCircle = _circleRenderer.sortingOrder;
            _initialOrderOfLine = _lineRenderer.sortingOrder;
            _initialOrderOfArrow = _arrowRenderer.sortingOrder;
            _initialOrderOfSniper = _sniperRenderer.sortingOrder;
        }
                       

        public void OnBeginDrag(PointerEventData eventData)
        {
            OrderChanger(true);
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OrderChanger(false);
        }

        
        void OrderChanger(bool isInitialOrderReturn)
        {
            if(isInitialOrderReturn)
            {
                _playerRenderer.sortingOrder = _initialOrderOfPlayer + 3;
                _edgeRenderer.sortingOrder = _initialOrderOfEdge + 3;
                _circleRenderer.sortingOrder = _initialOrderOfCircle + 3;
                _lineRenderer.sortingOrder = _initialOrderOfLine + 3;
                _arrowRenderer.sortingOrder = _initialOrderOfArrow + 3;
                _sniperRenderer.sortingOrder = _initialOrderOfSniper + 50;
            }
            else
            {
                _playerRenderer.sortingOrder = _initialOrderOfPlayer;
                _edgeRenderer.sortingOrder = _initialOrderOfEdge;
                _circleRenderer.sortingOrder = _initialOrderOfCircle;
                _lineRenderer.sortingOrder = _initialOrderOfLine;
                _arrowRenderer.sortingOrder = _initialOrderOfArrow;
                _sniperRenderer.sortingOrder = _initialOrderOfSniper;
            }
        }

        
    }
}
