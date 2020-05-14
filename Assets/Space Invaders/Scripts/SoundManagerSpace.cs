using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerSpace : MonoBehaviour

{
    public static AudioClip shootSound, pingSound, impactSound;
    static AudioSource audioSrc;
    public AudioClip shoot, ping, impact;


    void Start() {
        shootSound = shoot;
        pingSound = ping;
        impactSound = impact;
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "shoot":
                audioSrc.PlayOneShot(shootSound);
                break;
            case "ping":
                audioSrc.PlayOneShot(pingSound);
                break;
            case "impact":
                audioSrc.PlayOneShot(impactSound);
                break;

        }
    }

}