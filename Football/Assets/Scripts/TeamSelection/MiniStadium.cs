using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace FootBall
{
    /// <summary>
    /// Mini Stadium uchun left va right buttonlarni joyini moslashtiradi. 
    /// </summary>
    public class MiniStadium : MonoBehaviour
    {
        public Canvas MyCanvas;
        public RectTransform LeftButton;
        public RectTransform RightButton;
        private Transform _miniStadium;


        private void Start()
        {
            _miniStadium = gameObject.GetComponent<Transform>();

            DeviceDetector(Screen.width, Screen.height);
        }       


        public void DeviceDetector(float width, float height)
        {            // ushbu kod deviceni ni tekshirib beradi. Bazi o'yin obyektlari devicega qarab o'z pozitsiyasini o'zgartiradi.
            if (width / height >= 2)
            {
                //Debug.Log("Long phone.");
                LeftButton.anchoredPosition = new Vector3(-130, -55, 0);
                RightButton.anchoredPosition = new Vector3(130, -55, 0);
            }
            else if (width / height > 1.5f)
            {
                //Debug.Log("Phone");
                LeftButton.anchoredPosition = new Vector3(-160, -65, 0);
                RightButton.anchoredPosition = new Vector3(160, -65, 0);
            }
            else if (width / height < 1.5f)
            {
                //Debug.Log("Tablet");
                LeftButton.anchoredPosition = new Vector3(-200, -90, 0);
                RightButton.anchoredPosition = new Vector3(200, -90, 0);
            }
        }


        void ButtonPosition()
        {
            Debug.Log(Screen.width + "   " + Screen.height);
            Debug.Log(MyCanvas.GetComponent<CanvasScaler>().referenceResolution);
        }


        //void SetPositions()
        //{
        //    Vector2 miniStadiumScreenPos = RectTransformUtility.WorldToScreenPoint(MyCanvas.worldCamera, _miniStadium.position);
        //    Debug.Log(miniStadiumScreenPos);

        //    LeftButton.anchoredPosition = new Vector2(miniStadiumScreenPos.x - Screen.width / 2, miniStadiumScreenPos.y);

        //    RightButton.anchoredPosition = new Vector2(miniStadiumScreenPos.x + Screen.width / 2, miniStadiumScreenPos.y);
        //}
    }
}
