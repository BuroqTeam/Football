using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class ArrowLineRenderer : MonoBehaviour
    {

        private LineRenderer _lineRenderer;
        private GameObject _arrowObject;


        #region MonoBehaviour Callbacks
        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _arrowObject = transform.GetChild(0).gameObject;
        }
        
        #endregion


        #region Methods
        public void DrawLine(float lengthOfMouseDrag, float maxCircleSize, Vector3 initialMousePosition, Vector3 currentMousePosition)
        {
            _lineRenderer.SetPosition(1, (2 * initialMousePosition - currentMousePosition));
            if (lengthOfMouseDrag >= maxCircleSize * 0.5f)
            {
                Vector3 startPoint = _lineRenderer.GetPosition(0);
                Vector3 endPoint = _lineRenderer.GetPosition(1);
                float ratio = (maxCircleSize * 0.5f) / Vector3.Distance(startPoint, endPoint);
                float newX = startPoint.x + ratio * (endPoint.x - startPoint.x);
                float newY = startPoint.y + ratio * (endPoint.y - startPoint.y);
                float newZ = startPoint.z;
                _lineRenderer.SetPosition(1, new Vector3(newX, newY, newZ));
            }
            SetArrowPosition();
        }

        public void SetFirstLineRendererPosition(Vector3 initialMousePosition)
        {
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, initialMousePosition);
        }

        public void RemoveLine()
        {
            _lineRenderer.positionCount = 0;
            //SetArrowPosition();
        }

        public Vector3 GetDirection()
        {
            if (_lineRenderer.positionCount >= 2)
            {
                Vector3 startPoint = _lineRenderer.GetPosition(0);
                Vector3 endPoint = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
                Vector3 direction = endPoint - startPoint;
                direction = new Vector3(direction.x, direction.y, 0);
                direction.Normalize();
                _lineRenderer.positionCount = 0;
                return direction;
            }
            else
            {
                _lineRenderer.positionCount = 0;
                return new Vector3();
            }
        }


        void SetArrowPosition()
        {
            if (_lineRenderer.positionCount == 2)
            {
                Vector3 direction = _lineRenderer.GetPosition(1) - _lineRenderer.GetPosition(0);
                float angle = Mathf.Atan2(direction.y, direction.x);
                                
                _arrowObject.transform.position = _lineRenderer.GetPosition(1);
                _arrowObject.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
            }            
        }


        /// <summary>
        /// When Dragging is finish this method called and Arrow gameObject to initialPos. 
        /// </summary>
        public void ResetArrowPos()
        {
            _arrowObject.transform.localPosition = new Vector2(0, 0);
            //Debug.Log("Remove Arrow");
        }
        #endregion

    }

}


