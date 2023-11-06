using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace FootBall
{
    public class Menu : MonoBehaviour
    {



        public virtual void OnEnter(Sprite enterSprite, UnityEvent onPointerEnterEvent)
        {
            GetComponent<Button>().image.sprite = enterSprite;
            onPointerEnterEvent.Invoke();
        }

        public virtual void OnExit(Sprite exitSprite)
        {
            GetComponent<Button>().image.sprite = exitSprite;
        }



    }

}

