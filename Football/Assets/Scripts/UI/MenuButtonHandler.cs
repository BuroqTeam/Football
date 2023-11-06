using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;

namespace FootBall
{
    public class MenuButtonHandler : Menu, IPointerEnterHandler, IPointerExitHandler
    {
        public MenuButton MenuButtonSO;
        private Button _button;

        public UnityEvent OnPointerEnterEvent;


        private void Awake()
        {
            _button = GetComponent<Button>();
        }



        public void OnPointerEnter(PointerEventData eventData)
        {
            OnEnter(MenuButtonSO.FramedSp, OnPointerEnterEvent);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnExit(MenuButtonSO.PlainSp);                        
        }


        public override void OnEnter(Sprite enterSprite, UnityEvent onPointerEnterEvent)
        {
            base.OnEnter(enterSprite, onPointerEnterEvent);
            _button.transform.GetChild(0).GetComponent<TMP_Text>().fontSize = MenuButtonSO.BiggerFontSize;
            _button.transform.GetChild(0).GetComponent<TMP_Text>().color = MenuButtonSO.LightColor;

        }

        public override void OnExit(Sprite exitSprite)
        {
            base.OnExit(exitSprite);
            _button.transform.GetChild(0).GetComponent<TMP_Text>().fontSize = MenuButtonSO.NomalFontSize;
            _button.transform.GetChild(0).GetComponent<TMP_Text>().color = MenuButtonSO.NormalColor;
        }



    }

}

