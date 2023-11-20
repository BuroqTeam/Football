using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class ArrowLineRenderer : MonoBehaviour
    {

        private LineRenderer _lineRenderer;


        #region MonoBehaviour Callbacks
        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();            
        }


        private void Start()
        {
            //ChangeLineColor();
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


        void ChangeLineColor()
        {
            Debug.Log("Work color change");
            Material newMat = (_lineRenderer.material);
            newMat.color = Color.red/*new Color(0.83f, 0.2f, 0.2f)*/;
            _lineRenderer.material = newMat; 
        }
        #endregion

    }

}


