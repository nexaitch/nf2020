using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHealth : MonoBehaviour
{
    public Vector3 durianOffset = new Vector3(0, 1f, 0);
    public GameObject drop;



    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (gameObject.tag == "Bullet")
        {
            if (target.tag == "Alien")
            {
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
