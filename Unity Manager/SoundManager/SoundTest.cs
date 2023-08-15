using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    
    void Start()
    {
        Managers.Sound.Play("BGM/Winter Festival",Define.Sound.Effect);
    }

}
