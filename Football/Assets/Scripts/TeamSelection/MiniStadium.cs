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
        private Transform _miniStadium;

        [Header("First team Buttons")]
        public RectTransform FirstTeamRightButton;
        public RectTransform FirstTeamLeftButton;

        [Header("First team Buttons")]
        public RectTransform SecondTeamRightButton;
        public RectTransform SecondTeamLeftButton;


        private void Start()
        {
            _miniStadium = gameObject.GetComponent<Transform>();

            DeviceDetectorSetPosition(Screen.width, Screen.height);
            //DeviceDetector(Screen.width, Screen.height);
        }


        public void DeviceDetectorSetPosition(float width, float height)
        {            // ushbu kod deviceni ni tekshirib beradi. Bazi o'yin obyektlari devicega qarab o'z pozitsiyasini o'zgartiradi.
            if (width / height >= 2)
            {
                //Debug.Log("Long phone.");
                FirstTeamRightButton.anchoredPosition = new Vector3(55, 42.5f, 0);
                FirstTeamLeftButton.anchoredPosition = new Vector3(55, -123, 0);
                SecondTeamRightButton.anchoredPosition = new Vector3(-55, 42.5f, 0);
                SecondTeamLeftButton.anchoredPosition = new Vector3(-55, -123, 0);
            }
            else if (width / height > 1.5f)
            {
                //Debug.Log("Phone");
                FirstTeamRightButton.anchoredPosition = new Vector3(65, 55, 0);
                FirstTeamLeftButton.anchoredPosition = new Vector3(65, -165, 0); // -150
                SecondTeamRightButton.anchoredPosition = new Vector3(-65, 55, 0);
                SecondTeamLeftButton.anchoredPosition = new Vector3(-65, -165, 0); // -150
            }
            else if (width / height < 1.5f)
            {
                //Debug.Log("Tablet");
                FirstTeamRightButton.anchoredPosition = new Vector3(80, 65, 0);
                FirstTeamLeftButton.anchoredPosition = new Vector3(80, -195, 0);
                SecondTeamRightButton.anchoredPosition = new Vector3(-80, 65, 0);
                SecondTeamLeftButton.anchoredPosition = new Vector3(-80, -195, 0);
            }
        }




        //void ButtonPosition()
        //{
        //    Debug.Log(Screen.width + "   " + Screen.height);
        //    Debug.Log(MyCanvas.GetComponent<CanvasScaler>().referenceResolution);
        //}


        //public void DeviceDetector(float width, float height)
        //{            // ushbu kod deviceni ni tekshirib beradi. Bazi o'yin obyektlari devicega qarab o'z pozitsiyasini o'zgartiradi.
        //    if (width / height >= 2)
        //    {
        //        //Debug.Log("Long phone.");
        //        LeftButton.anchoredPosition = new Vector3(-130, -55, 0);
        //        RightButton.anchoredPosition = new Vector3(130, -55, 0);
        //    }
        //    else if (width / height > 1.5f)
        //    {
        //        //Debug.Log("Phone");
        //        LeftButton.anchoredPosition = new Vector3(-160, -65, 0);
        //        RightButton.anchoredPosition = new Vector3(160, -65, 0);
        //    }
        //    else if (width / height < 1.5f)
        //    {
        //        //Debug.Log("Tablet");
        //        LeftButton.anchoredPosition = new Vector3(-200, -90, 0);
        //        RightButton.anchoredPosition = new Vector3(200, -90, 0);
        //    }
        //}
        
    }
}
