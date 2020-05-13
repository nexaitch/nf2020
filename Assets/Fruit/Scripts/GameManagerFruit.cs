using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFruit : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;

    public int P1Life;
    public int P2Life;
    public int P3Life;

    public GameObject gameOver;

    public GameObject[] p1Hearts;
    public GameObject[] p2Hearts;
    public GameObject[] p3Hearts;

    void Start()
    {

    }

    void Update ()
    {
        if(P1Life <= 0)
        {
            player1.SetActive(false);
            Spawner1.SetActive(false);

        }
        else if (P2Life <= 0)
        {
            player2.SetActive(false);
            Spawner2.SetActive(false);
        }
        else if (P3Life <= 0)
        {
            player3.SetActive(false);
            Spawner3.SetActive(false);
        }
        else if (P1Life <= 0 && P2Life <= 0 && P3Life <= 0)
        {

            gameOver.SetActive(true);
        }
    }

    public void HurtP1()
    {
        P1Life -= 1;
        for(int i = 0; i < p1Hearts.Length; i++)
        {
            if(P1Life >i)
            {
                p1Hearts[i].SetActive(true);
            }
            else
            {
                p1Hearts[i].SetActive(false);
            }
        }
    }
    public void HurtP2()
    {
        P2Life -= 1;
        for (int i = 0; i < p2Hearts.Length; i++)
        {
            if (P2Life > i)
            {
                p2Hearts[i].SetActive(true);
            }
            else
            {
                p2Hearts[i].SetActive(false);
            }
        }
    }
    public void HurtP3()
    {
        P3Life -= 1;
        for (int i = 0; i < p3Hearts.Length; i++)
        {
            if (P3Life > i)
            {
                p3Hearts[i].SetActive(true);
            }
            else
            {
                p3Hearts[i].SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        Destroy(target.gameObject);
    }
}

   

