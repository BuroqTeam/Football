using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    public class SoundManager : MonoBehaviour
    {
        public SoundKey SoundKeySO;

        private void Awake()
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(SoundKeySO.KeyForSound);
            transform.GetChild(0).GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(SoundKeySO.KeyForMusic);
        }

    }

}

