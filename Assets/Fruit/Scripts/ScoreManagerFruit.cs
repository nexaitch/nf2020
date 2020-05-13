using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManagerFruit : MonoBehaviour
{
    public GameObject player;
    public int playernumber;


    public Text scoreText;


    public int PScore;


    // Update is called once per frame
    void Update()
    {
        scoreText.text = PScore.ToString(); // converts score int to text
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (playernumber == 1)
        {
            if (target.tag == "Bomb")
                FindObjectOfType<GameManagerFruit>().HurtP1(); // finds GameManager and runs Hurt player script
            Destroy(target.gameObject);
        }
        else if (playernumber == 2)
        {
            if (target.tag == "Bomb")
                FindObjectOfType<GameManagerFruit>().HurtP2();
            Destroy(target.gameObject);
        }
        else if (playernumber == 3)
        {
            if (target.tag == "Bomb")
                FindObjectOfType<GameManagerFruit>().HurtP3();
            Destroy(target.gameObject);
        }

    }
    void OnTriggerExit2D(Collider2D target)
    {
            if (target.tag == "Fruit") //adds score if fruit passes through player
                PScore++;
            Destroy(target.gameObject);
            SoundManagerFruit.PlaySound("ping");
        

    }
}
