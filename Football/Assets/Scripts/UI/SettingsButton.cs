using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;

namespace FootBall
{
    public class SettingsButton : Menu, IPointerEnterHandler, IPointerExitHandler
    {
        public MenuButton SeetingsButtonSO;


        public UnityEvent OnPointerEnterEvent;



        public void OnPointerEnter(PointerEventData eventData)
        {
            OnEnter(SeetingsButtonSO.FramedSp, OnPointerEnterEvent);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnExit(SeetingsButtonSO.PlainSp);
        }


        public override void OnEnter(Sprite enterSprite, UnityEvent onPointerEnterEvent)
        {
            base.OnEnter(enterSprite, onPointerEnterEvent);

        }

        public override void OnExit(Sprite exitSprite)
        {
            base.OnExit(exitSprite);
        }


    }


}
