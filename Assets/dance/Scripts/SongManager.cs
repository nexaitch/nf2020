using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    // current position of the song (in seconds)
    public float songPosition { get; private set; }
    // current position of the song (in beats)
    public float songPosInBeats { get; private set; }
    // time since song started (in seconds)
    public float dsptimesong { get; private set; }
    public float bpm;
    public float firstBeatOffset;
    public float songStartOffset;
    public AudioSource musicSource;
    public SongInfo songInfo;
    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.time = songStartOffset;
        dsptimesong = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dsptimesong - firstBeatOffset);
        songPosInBeats = songPosition * bpm / 60f;
    }
}
