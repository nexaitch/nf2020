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
            Instantiate(fruits[randomFruit],
                new Vector2(Random.Range(xBounds1, xBounds2), yBound), Quaternion.identity);

        else
            Instantiate(bomb,
                 new Vector2(Random.Range(xBounds1, xBounds2), yBound),Quaternion.identity);

       StartCoroutine(SpawnRandomGameObject());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
