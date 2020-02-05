using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerFruit : MonoBehaviour

{
    public static AudioClip knifeSound, pingSound, bombSound, splatSound;
    static AudioSource audioSrc;
    public AudioClip knife, ping, bomb, splat;


    void Start() {
        knifeSound = knife;
        pingSound = ping;
        bombSound = bomb;
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
            case "bomb":
                audioSrc.PlayOneShot(bombSound);
                break;
            case "splat":
                audioSrc.PlayOneShot(splatSound);
                break;

        }
    }

}