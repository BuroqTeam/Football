using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FootBall
{
    public class ClickSound : MonoBehaviour
    {
        public string Key;       
        public Slider Slider;
        public AudioSource AudioSource;

        private void Awake()
        {
            PlayerPrefs.SetFloat(Key, AudioSource.volume);
        }


        private void Start()
        {
            Slider.value = PlayerPrefs.GetFloat(Key);
            AudioSource.volume = Slider.value;
        }


        public void SaveValue()
        {
            PlayerPrefs.SetFloat(Key, Slider.value);
            
        }


        public void ChangeVolume()
        {
            AudioSource.volume = Slider.value;
        }

       




    }

}

