using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandlerFruit : MonoBehaviour
{
    public int health = 1;
    public float bomb;
    public GameObject odurian;
    int correctLayer;
    public Vector3 durianOffset = new Vector3(0, 1f, 0);

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;

        // NOTE!  This only get the renderer on the parent object.
        // In other words, it doesn't work for children. I.E. "enemy01"
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }

    void OnTriggerEnter2D()
    {
        health--;

    }

    void Update()
    {


        if (health <= 0)
        {
            if (bomb == 1f)
            {
                SoundManagerFruit.PlaySound("bomb");
                Vector3 offset = transform.rotation * durianOffset;
                Instantiate(odurian, transform.position + offset, transform.rotation);
                
                Die(); }
            else
                SoundManagerFruit.PlaySound("splat");
                Die();

        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
