using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using UnityEngine.Events;
using Unity.VisualScripting;

namespace FootBall
{
    public class BoardAnimation : MonoBehaviour
    {
        public Canvas MainCanvas;
        public GameObject TopPanel;
        public GameObject Buttons;
        public GameObject RightTeam;
        public GameObject LeftTeam;
        public GameObject VsObject;
        
        public GameObject BlurGameObject;
        private GameObject BoardGameObject;

        private Vector2 _canvasSize;
        private Vector2 _referenceResolution;
        public BoolVariable StartAnimFinished;

        public UnityEvent TeamCreateEvent;

        private void Awake()
        {
            //BlurGameObject = gameObject.transform.GetChild(0).gameObject;
            BoardGameObject = gameObject.transform.GetChild(0).gameObject;
            
            _canvasSize = MainCanvas.GetComponent<RectTransform>().sizeDelta;
            _referenceResolution = MainCanvas.GetComponent<CanvasScaler>().referenceResolution;            
        }


        void Start()
        {
            InitialSettings();
            
            StartCoroutine(UIAnimate());
        }


        IEnumerator UIAnimate()
        {
            BlurGameObject.SetActive(true);
            BoardGameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);

            BoardGameObject.GetComponent<MoveAnim>().MoveToInitialLocalPos(0.75f);
            yield return new WaitForSeconds(0.7f);

            LeftTeam.GetComponent<MoveAnim>().ChangeScale(1, 0.35f);
            RightTeam.GetComponent<MoveAnim>().ChangeScale(1, 0.35f);
            yield return new WaitForSeconds(1f);

            VsObject.GetComponent<RectTransform>().DOScale(1, 0.3f);
            yield return new WaitForSeconds(1f);

            BoardGameObject.GetComponent<MoveAnim>().MoveOutLeft(1);
            yield return new WaitForSeconds(1f);

            BlurGameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);

            TeamCreateEvent.Invoke();
            //TopPanel.GetComponent<MoveAnim>().MoveToInitialAnchoredPos(0.5f);
            //yield return new WaitForSeconds(0.5f);

            //StartAnimFinished.Value = true;
            
        }


        public void TopPanelMove()
        {
            Buttons.GetComponent<MoveAnim>().MoveToInitialAnchoredPos(0.5f);
            TopPanel.GetComponent<MoveAnim>().MoveToInitialAnchoredPos(0.5f);
            StartAnimFinished.Value = true;
        }


        void InitialSettings()
        {
            //BoardGameObject.GetComponent<RectTransform>().DOAnchorPosX(_referenceResolution.x / 2 + BoardGameObject.GetComponent<RectTransform>().sizeDelta.x, 0);
            BoardGameObject.GetComponent<MoveAnim>().MoveOutRight(0);
            Buttons.GetComponent<MoveAnim>().MoveOutBottom(0);

            LeftTeam.GetComponent<MoveAnim>().ChangeScale(0, 0);
            RightTeam.GetComponent<MoveAnim>().ChangeScale(0, 0);

            VsObject.transform.localScale = new Vector3(0, 0, 0);
            TopPanel.GetComponent<MoveAnim>().MoveOutTop(0);
        }
                
    }
}
