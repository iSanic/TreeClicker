using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleManager : MonoBehaviour
{
    public Click_manager cm;
    public Move_Player mp;
    public Text[] countWoodText = new Text[2];
    public int[] countWood = new int[2];


    public GameObject NoWood;
    public GameObject WoodForSale;

    public AudioSource SaleWood;

    private void Update()
    {
        if (cm.woodscore != 0)
        {
            int sum = 0;
            for (int i = 0; i < countWoodText.Length; i++)
            {
                sum = countWood[i] * mp.woodIndex[i];
                countWoodText[i].text = "x " + mp.woodIndex[i] + " = " + sum + "$";
            }
        }
       isWood();
    }

    public void Sale()
    {
        SaleWood.Play();
        int sum = 0;
        for (int i = 0; i < countWood.Length; i++)
        {
            sum += countWood[i] * mp.woodIndex[i];
            mp.woodIndex[i] = 0;
        }

        cm.score += sum;
        cm.woodscore = 0;
        sum = 0;
    }

    void isWood()
    {
        if (cm.woodscore <= 0)
        {
            WoodForSale.SetActive(false);
            NoWood.SetActive(true);
        }
        else
        {
            WoodForSale.SetActive(true);
            NoWood.SetActive(false);
        }
    }

}
