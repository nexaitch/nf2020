using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitHealth : MonoBehaviour
{
    public Vector3 durianOffset = new Vector3(0, 1f, 0);
    public GameObject odurian;



    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (gameObject.tag == "Knife")
        {
            if (target.tag == "Fruit")
            {
                SoundManagerFruit.PlaySound("splat");
                Destroy(target.gameObject);
                Die();
            }
            else if (target.tag == "Bomb")
            {
                SoundManagerFruit.PlaySound("splat");
                Vector3 offset = transform.rotation * durianOffset;
                Instantiate(odurian, transform.position + offset, transform.rotation);
                Destroy(target.gameObject);
                Die();
            }

        }


    }

    void Die()
    {
        Destroy(gameObject);
    }
}
