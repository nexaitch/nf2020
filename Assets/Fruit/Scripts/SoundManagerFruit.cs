using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerFruit : MonoBehaviour

{
    public static AudioClip knifeSound, pingSound, splatSound;
    static AudioSource audioSrc;
    public AudioClip knife, ping, splat;


    void Start() {
        knifeSound = knife;
        pingSound = ping;
        splatSound = splat;
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "knife":
                audioSrc.PlayOneShot(knifeSound);
                break;
            case "ping":
                audioSrc.PlayOneShot(pingSound);
                break;
            case "splat":
                audioSrc.PlayOneShot(splatSound);
                break;

        }
    }

}