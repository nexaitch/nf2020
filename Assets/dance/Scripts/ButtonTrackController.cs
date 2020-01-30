using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrackController : MonoBehaviour {
    public GameObject notePrefab;
    public Sprite buttonUnpressedSprite, buttonPressedSprite, noteSprite;
    public Color flashColor;
    public string axis;
    private SongManager songManager;
    private Queue<NoteController> noteQueue;
    private TrackGroupController tgc;
    public GameObject button { get; private set; }
    public GameObject trackFlash { get; private set; }

    void Start(){
        songManager = GameObject.Find("Conductor").GetComponent<SongManager>();
        noteQueue = new Queue<NoteController>();
        tgc = GetComponentInParent<TrackGroupController>();
    }

    public void spawnNote(float beatNumber, float scrollSpeed) {
        GameObject note = Instantiate(notePrefab, transform);
        NoteController noteController = note.GetComponent<NoteController>();
        note.GetComponent<SpriteRenderer>().sprite = noteSprite;
        noteController.scrollSpeed = scrollSpeed;
        noteController.targetTime = beatNumber * 60f / songManager.bpm;
        noteQueue.Enqueue(noteController);
    }

    const float failWindow = 0.15f,
        okWindow = 0.09f,
        perfectWindow = 0.03f;
    void Update() {
        while (noteQueue.Count > 0 && songManager.songPosition - noteQueue.Peek().targetTime > failWindow) {
            tgc.ChangeJudgement(HitGrading.FAIL);
            Destroy(noteQueue.Peek().gameObject);
            noteQueue.Dequeue();
        }

        if (Input.GetButtonDown(axis) && noteQueue.Count > 0) {
            float delta = songManager.songPosition - noteQueue.Peek().targetTime;
            if (delta > -perfectWindow && delta < perfectWindow) {
                tgc.ChangeJudgement(HitGrading.PERFECT);
                Destroy(noteQueue.Peek().gameObject);
                noteQueue.Dequeue();
            } else if (delta > -okWindow && delta < okWindow) {
                tgc.ChangeJudgement(HitGrading.OK);
                Destroy(noteQueue.Peek().gameObject);
                noteQueue.Dequeue();
            } else if (delta > -failWindow && delta < failWindow) {
                tgc.ChangeJudgement(HitGrading.FAIL);
                Destroy(noteQueue.Peek().gameObject);
                noteQueue.Dequeue();

            }
        }
    }
}
