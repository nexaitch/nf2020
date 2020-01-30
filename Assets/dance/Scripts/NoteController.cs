using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    // in units per second
    public float scrollSpeed;
    public Vector3 target = Vector3.zero;
    public Vector3 direction = Vector3.down;
    public float targetTime;
    private SongManager songManager;
    public bool isActive { get; private set; }
    public float expirePosition = 3f;
    // Start is called before the first frame update
    void Start()
    {
        songManager = GameObject.Find("Conductor").GetComponent<SongManager>();
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = target + (songManager.songPosition - targetTime) * scrollSpeed * direction;
    }
}
