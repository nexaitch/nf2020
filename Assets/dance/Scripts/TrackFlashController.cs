using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackFlashController : MonoBehaviour {
    ButtonTrackController buttonTrackController;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        buttonTrackController = GetComponentInParent<ButtonTrackController>();
        if (buttonTrackController == null) {
            Debug.LogError("Needs a button track parent to work!", gameObject);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(buttonTrackController.axis)) {
            spriteRenderer.color = buttonTrackController.flashColor;
        }
        if (Input.GetButtonUp(buttonTrackController.axis)) {
            spriteRenderer.color = Color.clear;
        }
    }
}
