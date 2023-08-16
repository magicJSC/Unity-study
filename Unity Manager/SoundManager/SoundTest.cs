using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioClip AudioClip;
    void Start()
    {
        Managers.Sound.Play(AudioClip,Define.Sound.Effect);
    }

}
