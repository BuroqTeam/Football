using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    /// <summary>
    /// This script is responsible for drawing sniper line.
    /// </summary>
    public class SniperLineRenderer : MonoBehaviour
    {
        #region Fields
        private LineRenderer _lineRenderer;
        public IntVariable SniperValue;
        #endregion

        #region MonoBehaviour CallBacks
        void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }      
        #endregion


        public void DrawSniperLine()
        {
            if (SniperValue.Value % 2 == 0)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 directionOfSniper = (transform.position - mousePosition).normalized;                
                
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionOfSniper);
                RaycastHit2D lineTestHit;

                foreach (RaycastHit2D hit in hits)
                {
                    // Do something with each hit.collider
                    if (hit.collider.gameObject.name.Equals("Line_Test"))
                    {
                        lineTestHit = hit;
                        //Debug.Log(lineTestHit.point);

                        _lineRenderer.SetPosition(1, new Vector3(lineTestHit.point.x, lineTestHit.point.y, -0.01f));
                        break;
                    }
                }

            }            
        }


        public void SetFirstLineRendererPosition(Vector3 initialMousePosition)
        {
            if (SniperValue.Value % 2 == 0)
            {
                _lineRenderer.positionCount = 2;
                _lineRenderer.SetPosition(0, new Vector3(initialMousePosition.x, initialMousePosition.y, -0.01f));
            }
        }


        /// <summary>
        /// Remove sniper line. 
        /// </summary>
        public void RemoveLine()
        {
            _lineRenderer.positionCount = 0;
        }

    }
}

