using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFruit : MonoBehaviour
{
    public GameObject[] fruits; // allows the adding of more fruit prefabs if needed
    public GameObject bomb;

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

        int randomFruit = Random.Range(0, fruits.Length);

        if (Random.value <= .6f)
        {
            randomFruit = Random.Range(0, fruits.Length);// this is to randomly spawn fruits and bombs in a random order
            x = Random.Range(0, 3);
            if (x == 0)
                Instantiate(fruits[randomFruit],
                    new Vector2(xBounds1, yBound), Quaternion.identity);// spawns item only at a certain x and y position
            else if (x == 1)
                Instantiate(fruits[randomFruit],
                new Vector2(xBounds2, yBound), Quaternion.identity);
            else if (x == 2)
                Instantiate(fruits[randomFruit],
                new Vector2(xBounds3, yBound), Quaternion.identity);
        }
        else
        {
            x = Random.Range(0, 3);
            if (x == 0)
                Instantiate(bomb,
                new Vector2(xBounds1, yBound), Quaternion.identity);
            else if (x == 1)
                Instantiate(bomb,
                new Vector2(xBounds2, yBound), Quaternion.identity);
            else if (x == 2)
                Instantiate(bomb,
                new Vector2(xBounds3, yBound), Quaternion.identity);
        }

       StartCoroutine(SpawnRandomGameObject());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
