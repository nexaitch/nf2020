using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knifethrowing : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public float player;
    int bulletLayer;

    public float fireDelay = 5f;
    float cooldownTimer = 0;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 1f)
        {
            cooldownTimer -= Time.deltaTime;

            if (Input.GetButton("P1M") && cooldownTimer <= 0)// we want it to fire when middle button is pressed but not spam fire
            {
                // SHOOT!
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * bulletOffset;
                SoundManagerFruit.PlaySound("knife");
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                bulletGO.layer = bulletLayer;
            }
        }
        else if (player == 2f)
        {
            cooldownTimer -= Time.deltaTime;

            if (Input.GetButton("P2M") && cooldownTimer <= 0)
            {
                // SHOOT!
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * bulletOffset;
                SoundManagerFruit.PlaySound("knife");
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                bulletGO.layer = bulletLayer;
            }
        }
        else if (player == 3f)
        {
            cooldownTimer -= Time.deltaTime;

            if (Input.GetButton("P3M") && cooldownTimer <= 0)
            {
                // SHOOT!
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * bulletOffset;
                SoundManagerFruit.PlaySound("knife");
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                bulletGO.layer = bulletLayer;
            }
        }
    }
}
