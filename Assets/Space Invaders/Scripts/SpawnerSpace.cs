using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpace : MonoBehaviour
{
    public GameObject[] Aliens; // allows the adding of more enemy prefabs if needed

    public float yBound;
    public float xBounds1;
    public float xBounds2;
    public float xBounds3;
    int x;

   
    void Start()
    {
        StartCoroutine(SpawnRandomGameObject());
    }
    // continuosly run SpawnRandomGameObject
    IEnumerator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));

        int randomAlien = Random.Range(0, Aliens.Length);

        if (Random.value <= .6f)
        {
            randomAlien = Random.Range(0, Aliens.Length);// this is to randomly spawn enemies in a random order
            x = Random.Range(0, 3);
            if (x == 0)
                Instantiate(Aliens[randomAlien],
                    new Vector2(xBounds1, yBound), Quaternion.identity);// spawns item only at a certain x and y position
            else if (x == 1)
                Instantiate(Aliens[randomAlien],
                new Vector2(xBounds2, yBound), Quaternion.identity);
            else if (x == 2)
                Instantiate(Aliens[randomAlien],
                new Vector2(xBounds3, yBound), Quaternion.identity);
        }


       StartCoroutine(SpawnRandomGameObject());
    }

}
