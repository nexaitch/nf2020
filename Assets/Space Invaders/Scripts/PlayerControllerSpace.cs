using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSpace : MonoBehaviour
{

    Vector2 i_movement;
    public float player;
    public float xbound1;
    public float xbound2;
    public float xbound3;
    public float fireDelay = 0.1f;
    float cooldownTimer = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playermove();

    }

    void playermove()
    {
        //Controls
        if (player == 1f)

        {
            if (Input.GetButton("P1L"))
            {
                cooldownTimer -= Time.deltaTime;

                Vector3 pos = transform.position;
                
                if (transform.position.x == xbound2 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound1, transform.position.y);
                }
                else if (transform.position.x == xbound3 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound2, transform.position.y);
                }


            }


            else if (Input.GetButton("P1R"))
            {
                cooldownTimer -= Time.deltaTime;
                Vector3 pos = transform.position;

                if (transform.position.x == xbound2 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound3, transform.position.y);
                }
                else if (transform.position.x == xbound1 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound2, transform.position.y);
                }
            }
        }
        else if (player == 2f)
        {
            if (Input.GetButton("P2L"))
            {
                cooldownTimer -= Time.deltaTime;

                Vector3 pos = transform.position;

                if (transform.position.x == xbound2 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound1, transform.position.y);
                }
                else if (transform.position.x == xbound3 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound2, transform.position.y);
                }


            }

            else if (Input.GetButton("P2R"))
            {
                cooldownTimer -= Time.deltaTime;
                Vector3 pos = transform.position;

                if (transform.position.x == xbound2 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound3, transform.position.y);
                }
                else if (transform.position.x == xbound1 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound2, transform.position.y);
                }
            }
        }
        else if (player == 3f)

        {
            if (Input.GetButton("P3L"))
            {
                cooldownTimer -= Time.deltaTime;

                Vector3 pos = transform.position;

                if (transform.position.x == xbound2 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound1, transform.position.y);
                }
                else if (transform.position.x == xbound3 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound2, transform.position.y);
                }


            }

            else if (Input.GetButton("P3R"))
            {
                cooldownTimer -= Time.deltaTime;
                Vector3 pos = transform.position;

                if (transform.position.x == xbound2 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound3, transform.position.y);
                }
                else if (transform.position.x == xbound1 && cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;
                    transform.position = new Vector2(xbound2, transform.position.y);
                }

            }
        }
    }
}