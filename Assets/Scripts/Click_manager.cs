using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Click_manager : MonoBehaviour
{
    public GameObject[] wood;
    public Transform woodPoint;
    public GameObject AxeEffect;

    public int woodscore = 0;
    public int woodscorePlus = 1;
    public int score = 0;

    public Text scoreText;
    public Text woodscoreText;

    public int rht1;
    public int rht2;


    private void Update()
    {
        scoreText.text = score + "$" ;
        woodscoreText.text = woodscore + " wood";
    }

    //Создание бревен
    public void clickTree()
    {
        Instantiate(AxeEffect, woodPoint.position + new Vector3(0,0,-10), Quaternion.Euler(0,0,0));
        int Scance1 = Random.Range(0, 3);

        int i0 = Random.Range(0, 3);
        while (i0 != 0)
        {
            Instantiate(wood[0], woodPoint.position, Quaternion.Euler(0, 0, Random.Range(rht1, rht2)));
            i0--;
        }
        if (Scance1 == 0) {
            int i1 = Random.Range(0, 2);
            while (i1 != 0)
            {
                Instantiate(wood[1], woodPoint.position, Quaternion.Euler(0, 0, Random.Range(rht1, rht2)));
                i1--;
            }
        }
    }

    //Количество бревен
    public void WoodScorePlus()
    {
        woodscore += woodscorePlus;
    }
}
