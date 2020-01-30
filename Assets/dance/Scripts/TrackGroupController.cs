using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HitGrading {
    FAIL,
    OK,
    PERFECT
}
public class TrackGroupController : MonoBehaviour
{
    SongManager songManager;
    public float scrollSpeed;
    public int noteToSpawn;
    List<Note> notes;
    public ButtonTrackController[] buttonTrackControllers;
    public SpriteRenderer judgementSpriteRenderer;
    public Sprite perfectSprite, okSprite, failSprite;
    const float fade = 3f;
    // Start is called before the first frame update
    void Start()
    {
        songManager = GameObject.Find("Conductor").GetComponent<SongManager>();
        scrollSpeed = songManager.bpm / 60f * 4f;
        noteToSpawn = 0;
        notes = songManager.songInfo.notes;
        judgementSpriteRenderer.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        while (noteToSpawn < notes.Count
            && (notes[noteToSpawn].beatNo - songManager.songPosInBeats) < 20f) {
            buttonTrackControllers[notes[noteToSpawn].track].spawnNote(notes[noteToSpawn].beatNo, scrollSpeed);
            ++noteToSpawn;
        }
        judgementSpriteRenderer.color = new Color(1, 1, 1, judgementSpriteRenderer.color.a * (1 - fade * Time.deltaTime));
    }

    public void ChangeJudgement(HitGrading grading) {
        if (grading == HitGrading.FAIL) {
            judgementSpriteRenderer.sprite = failSprite;
        } else if (grading == HitGrading.OK) {
            judgementSpriteRenderer.sprite = okSprite;
        } else if (grading == HitGrading.PERFECT) {
            judgementSpriteRenderer.sprite = perfectSprite;
        }
        judgementSpriteRenderer.color = Color.white;
    }
}
