using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Note {
    public float beatNo;
    public int track;
}

[CreateAssetMenu(fileName = "SongInfo", menuName = "Song Info")]
public class SongInfo : ScriptableObject
{
    public List<Note> notes;
}
