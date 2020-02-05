using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFruit : MonoBehaviour
{
    public float playerSpeedX = 10f;
    Vector2 i_movement;
    public float player;
    public float xbound1;
    public float xbound2;

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

        { if (Input.GetButton("P1L"))
            { Vector3 pos = transform.position;

                Vector3 velocity = new Vector3(playerSpeedX * Time.deltaTime,0, 0);

                pos -= transform.rotation * velocity;

                transform.position = pos; }

            else if (Input.GetButton("P1R"))
            { Vector3 pos = transform.position;

                Vector3 velocity = new Vector3(playerSpeedX * Time.deltaTime,0, 0);

                pos += transform.rotation * velocity;

                transform.position = pos; }
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, xbound1, xbound2), transform.position.y);
        }
        else if (player == 2f)

        {
            if (Input.GetButton("P2L"))
            {
                Vector3 pos = transform.position;

                Vector3 velocity = new Vector3(playerSpeedX * Time.deltaTime, 0, 0);

                pos -= transform.rotation * velocity;

                transform.position = pos;
            }

            else if (Input.GetButton("P2R"))
            {
                Vector3 pos = transform.position;

                Vector3 velocity = new Vector3(playerSpeedX * Time.deltaTime, 0, 0);

                pos += transform.rotation * velocity;

                transform.position = pos;
            }
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, xbound1, xbound2), transform.position.y);
        }

        else if (player == 3f)

        {
            if (Input.GetButton("P3L"))
            {
                Vector3 pos = transform.position;

                Vector3 velocity = new Vector3(playerSpeedX * Time.deltaTime, 0, 0);

                pos -= transform.rotation * velocity;

                transform.position = pos;
            }

            else if (Input.GetButton("P3R"))
            {
                Vector3 pos = transform.position;

                Vector3 velocity = new Vector3(playerSpeedX * Time.deltaTime, 0, 0);

                pos += transform.rotation * velocity;

                transform.position = pos;
            }
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, xbound1, xbound2), transform.position.y);
        }

    }




}