using UnityEngine;
using System.Collections;

public class Moveup : MonoBehaviour
{

    public float maxSpeed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }
}