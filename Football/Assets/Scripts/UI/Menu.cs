using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace FootBall
{
    public class Menu : MonoBehaviour
    {
        string userAgent;
        private void Start()
        {
            userAgent = SystemInfo.deviceName.ToLower();
        }

        public virtual void OnEnter(Sprite enterSprite, UnityEvent onPointerEnterEvent)
        {
            GetComponent<Button>().image.sprite = enterSprite;
            if (userAgent.Contains("desktop"))
            {
                onPointerEnterEvent.Invoke();
                Debug.Log("This is " + userAgent);
            }
        }

        public virtual void OnExit(Sprite exitSprite)
        {
            GetComponent<Button>().image.sprite = exitSprite;
        }



    }

}

