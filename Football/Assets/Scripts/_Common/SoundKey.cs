using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SoundKeys", menuName = "ScriptableObjects/SoundKeys", order = 4)]
public class SoundKey : ScriptableObject
{
    public string KeyForSound;
    public string KeyForMusic;
}
