using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sfx1, sfx2;

    public void Button1()
    {
        source.clip = sfx1;
        source.Play();
    }
    public void Button2()
    {
        source.clip = sfx1;
        source.Play();
    }
}
