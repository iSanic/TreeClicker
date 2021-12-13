using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Click_manager : MonoBehaviour
{
    public GameObject[] wood;   //Массив для разного вида дерева

    public Transform woodPoint; //Позиция точки откуда будет дроп бревен

    public GameObject AxeEffect;//Объект частиц стружки от удара по дереву

    public Move_Player mp;

    public int woodscore = 0;   //Общее количество бревен
    public int score = 0;       //Общее количество денег

    public Text scoreText;      //Текст денег
    public Text woodscoreText;  //Текст количетва бревен

    //Углы поворода по направлению которых могут полететь бревна
    public int rht1;
    public int rht2;


    //Каждый кадр обновлять текст на сцене
    private void Update()
    {
        scoreText.text = score + "$";
        woodscoreText.text = woodscore + " wood";
        int sum = 0;
        for (int i = 0; i < mp.woodIndex.Length; i++) sum += mp.woodIndex[i];
        woodscore = sum;
    }

    //Создание бревен
    public void clickTree()
    {
        Instantiate(AxeEffect, woodPoint.position + new Vector3(0, 0, -10), Quaternion.Euler(0, 0, 0));
        int Scance1 = Random.Range(0, 3);  //Шанс выпадения светрой древесины (так как можно получить одно из 4-х значение, то шанс равен 100/4 = 25%)

        int i0 = Random.Range(0, 3);   //Рандомное количество выпадения бревен_1
        while (i0 != 0)
        {
            i0--;
            Instantiate(wood[0], woodPoint.position, Quaternion.Euler(0, 0, Random.Range(rht1, rht2)));
        }
        if (Scance1 == 0)
        {
            int i1 = Random.Range(0, 2); //Рандомное количество выпадения бревен_2
            while (i1 != 0)
            {
                Instantiate(wood[1], woodPoint.position, Quaternion.Euler(0, 0, Random.Range(rht1, rht2)));
                i1--;
            }
        }
    }
}
