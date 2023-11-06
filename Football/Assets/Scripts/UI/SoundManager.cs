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
            if (PlayerPrefs.GetFloat(SoundKeySO.KeyForSound).Equals(0))
            {
                GetComponent<AudioSource>().volume = 1;
            }
            else
            {
                GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(SoundKeySO.KeyForSound);
            }

            if (PlayerPrefs.GetFloat(SoundKeySO.KeyForMusic).Equals(0))
            {
                GetComponent<AudioSource>().volume = 0.1f;
            }
            else
            {
                transform.GetChild(0).GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(SoundKeySO.KeyForMusic);
            }
        }

    }

}

