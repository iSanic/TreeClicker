using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaleManager : MonoBehaviour
{
    public Click_manager cm;
    public Move_Player mp;
    public Text[] countWoodText = new Text[2]; //Массив цен на бревна в тексте на экране
    public int[] countWood = new int[2];       //Массив цен на бревна          


    public GameObject NoWood;
    public GameObject WoodForSale;

    public AudioSource SaleWood;

    private void Update()
    {
        //Если есть бревна - выводить их колличесвто и сумму которую получит игрок за их продвжу 
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

    //Продажа бревен
    public void Sale()
    {
        SaleWood.Play();
        int sum = 0; //Сумма денег за бревна
        //Считаем сумму которую получим при продаже бревен 
        for (int i = 0; i < countWood.Length; i++)
        {
            sum += countWood[i] * mp.woodIndex[i]; //Кочиство бревен убножаем на их стоимость
            mp.woodIndex[i] = 0;                   
        }

        cm.score += sum;
        cm.woodscore = 0;                          //Обнуляем количетсво бревен - так как они проданы
        sum = 0;
    }

    //Если нет бревен - вывод текста что их нет, если есть то писать их количество
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
