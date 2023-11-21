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
            //_arrowObject = transform.GetChild(0).gameObject;
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
        }

        public void SetFirstLineRendererPosition(Vector3 initialMousePosition)
        {
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, initialMousePosition);
        }

        public void RemoveLine()
        {
            _lineRenderer.positionCount = 0;
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
                _arrowObject.transform.position = _lineRenderer.GetPosition(1);
            }
            else if (_lineRenderer.positionCount == 0)
            {
                _arrowObject.transform.position = new Vector2(0, 0);
            }
        }
        #endregion

    }

}


