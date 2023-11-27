using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FootBall
{
    public class TeamEmblemMove : MonoBehaviour
    {
        public Canvas MainCanvas;

        public GameObject RightTeam;
        public GameObject LeftTeam;
        public GameObject Ball;

        public GameObject TeamNameRight;
        public GameObject TeamNameLeft;
        public GameObject ScoreTablo;        

        private void Awake()
        {
            Ball.transform.localScale = new Vector3(0, 0, 0);

            //Vector2 canvasSize = MainCanvas.GetComponent<RectTransform>().sizeDelta;
            //TeamNameRight.GetComponent<RectTransform>().DOAnchorPosY(/*canvasSize.y + */TeamNameRight.GetComponent<RectTransform>().sizeDelta.y, 0.1f);

            //float cameraHeight = Camera.main.orthographicSize;
            //float cameraWidth = cameraHeight * Camera.main.aspect;
            //float exitXPosition = Camera.main.transform.position.x + cameraWidth + TeamNameRight.GetComponent<SpriteRenderer>().bounds.size.x;

            
        }


        void Start()
        {
            StartCoroutine(UIAnimate());

        }

        IEnumerator UIAnimate()
        {
            yield return new WaitForSeconds(0.5f);
            RightTeam.GetComponent<MoveAnim>().MoveCenter(0.75f);
            LeftTeam.GetComponent<MoveAnim>().MoveCenter(0.75f);
            yield return new WaitForSeconds(0.5f);
            Ball.GetComponent<RectTransform>().DOScale(1, 0.5f);

            yield return new WaitForSeconds(0.5f);



        }
       

        void MoveOut(GameObject obj)
        {
            //Debug.Log(Screen.width + " " + Screen.height);
            //Debug.Log(Camera.);
            //float newPosX = Screen.width / 2;
            //obj.GetComponent<RectTransform>().DOAnchorPosX(newPosX, 1);

            Vector3 objPos = obj.transform.position;
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(objPos);
            float screenWidth = Screen.width;
            float distanceToRight = screenWidth - screenPoint.x;
            Debug.Log("distanceToRight = " + distanceToRight);
            Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, obj.GetComponent<RectTransform>().position.y, obj.GetComponent<RectTransform>().position.z)));
        }



    }
}
