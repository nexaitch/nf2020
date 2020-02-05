using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public int player;
    private int score;
    public GameObject scorer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();   
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (player == 1f) ;
        {
            if (target.tag == "bomb")
                score++;
            Destroy(target.gameObject);
        }
        //health minus one? didn't add health yet because not sure how life will be counted

    }
}
