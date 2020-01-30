using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    ButtonTrackController buttonTrackController;
    // Start is called before the first frame update
    void Start()
    {
        buttonTrackController = GetComponentInParent<ButtonTrackController>();
        if (buttonTrackController == null) {
            Debug.LogError("Needs a button track parent to work!", gameObject);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = buttonTrackController.buttonUnpressedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(buttonTrackController.axis)) {
            spriteRenderer.sprite = buttonTrackController.buttonPressedSprite;
        }
        if (Input.GetButtonUp(buttonTrackController.axis)) {
            spriteRenderer.sprite = buttonTrackController.buttonUnpressedSprite;
        }
    }
}
