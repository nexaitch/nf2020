using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashSprite : MonoBehaviour
{
    GameObject conductor;
    SongManager songManager;
    SpriteRenderer spriteRenderer;
    [Range(0f, 1f)]
    public float minOpacity;
    [Range(0f, 1f)]
    public float maxOpacity;
    // Start is called before the first frame update
    void Start()
    {
        conductor = GameObject.Find("Conductor");
        if (conductor == null)
            Debug.LogError("needs an object named conductor to work!", gameObject);
        songManager = conductor.GetComponent<SongManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float cos = Mathf.Cos(2 * Mathf.PI * (songManager.songPosInBeats % 1f)) * 0.5f + 0.5f;
        Color c = spriteRenderer.color;
        c.a = minOpacity + (maxOpacity - minOpacity) * cos * cos * cos * cos;
        spriteRenderer.color = c;
    }
}
