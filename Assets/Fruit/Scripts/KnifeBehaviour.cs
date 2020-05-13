using UnityEngine;
using System.Collections;

public class KnifeBehaviour : MonoBehaviour
{
    // this code is just to get a gameobject to move up
    public float maxSpeed = 6f;
    public int ObjLife;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }
}