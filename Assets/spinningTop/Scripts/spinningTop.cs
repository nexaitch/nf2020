using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpinningTopGame
{

    public class spinningTop : MonoBehaviour
    {
        [SerializeField]
        public KeyCode redCode, greenCode, blueCode;

        [SerializeField]
        public GameObject spinDisk, playerOverlay, redKnob, greenKnob, blueKnob;

        [SerializeField]
        public float pushMagnitude = 1.0f;

        [SerializeField]
        public float spinMagnitude = 270.0f;

        [SerializeField]
        public bool clockwise = true;

        [SerializeField]
        public bool violentClash = true;

        [SerializeField]
        public float clashFactor = 0.4f;

        [SerializeField]
        AudioSource clashSound, scoreSound;

        bool frozen = false;
        
        
        [SerializeField]
        public uint score = 0;

        public Rigidbody2D body;
        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if(!frozen) {
                spin();
                processKeyPress();
            }
        }

        public void setKey(KeyCode redCode, KeyCode greenCode, KeyCode blueCode) {
            this.redCode = redCode;
            this.greenCode = greenCode;
            this.blueCode = blueCode;
        }

        void spin() {
            float resolvedRotation = spinMagnitude;
            if (clockwise) {
                resolvedRotation *= -1;
            }
            body.angularVelocity = resolvedRotation;

            // animation spin
            spinDisk.transform.Rotate(0,0, 5f * resolvedRotation * Time.deltaTime);
        }

        void processKeyPress() {

            Vector2 currentMomentum = new Vector2(0, 0);

            if (Input.GetKey(redCode)) {
                this.redKnob.transform.localScale = new Vector2(2, 2);
                currentMomentum += new Vector2(0, -0.4f);
            } else {
                this.redKnob.transform.localScale = new Vector2(1, 1);
            }
            
            if (Input.GetKey(greenCode)) {
                this.greenKnob.transform.localScale = new Vector2(2, 2);
                currentMomentum += new Vector2(0.32f, 0.2f);
            } else {
                this.greenKnob.transform.localScale = new Vector2(1, 1);
            }
            
            if (Input.GetKey(blueCode)) {
                this.blueKnob.transform.localScale = new Vector2(2, 2);
                currentMomentum += new Vector2(-0.32f, 0.2f);
            } else {
                this.blueKnob.transform.localScale = new Vector2(1, 1);
            }

            // Making it local momentum
            currentMomentum = transform.rotation * currentMomentum * pushMagnitude;

            body.AddForce(currentMomentum * Time.deltaTime, ForceMode2D.Impulse);
        }

        public void setPlayerColor(int red, int green, int blue) {
            Color playerColor = new Color(red / 255, green / 255, blue / 255, 0.5f);
            playerOverlay.GetComponent<SpriteRenderer>().color = playerColor;
            GetComponent<TrailRenderer>().material.color = playerColor;
        }

        public void freeze() {
            frozen = true;
            body.angularVelocity = 0;
            body.velocity = new Vector2(0, 0);
        }

        public void gainScore(uint scoreGained) {
            score += scoreGained;
            scoreSound.Play();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (violentClash) {
                spinningTop otherTop = col.collider.GetComponent<spinningTop>();
                if (otherTop != null) {
                    // [violentClash] in case of clashes between top, add opposing force
                    float clashMagnitude = (spinMagnitude + otherTop.spinMagnitude) * clashFactor * Time.deltaTime;
                    Vector2 clashDirection = (transform.position - otherTop.transform.position).normalized;
                    body.AddForce(clashDirection * clashMagnitude, ForceMode2D.Impulse);
                    clashSound.Play();
                }
            }
        }
    }

}