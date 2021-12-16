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
    [HideInInspector] public int rht1;
    [HideInInspector] public int rht2;

    [Header("Шансы")]
    public int[] scanseDrop = { 0, 3 };    //Шанс выпадение бревен
    public int[] Number = { 3, 2 };  //Количество бревен которое может выпасть
    public int[] enabledWood = { 0, 0 };   //Могут ли выпадать бревна


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
        for (int i = 0; i < mp.woodIndex.Length; i++)
        {
            int Scance = Random.Range(enabledWood[i], scanseDrop[i]);
            int woodSum = Random.Range(0, Number[i]);
            if (Scance == 0)
            {
                while (woodSum != 0)
                {
                    Instantiate(wood[i], woodPoint.position, Quaternion.Euler(0, 0, Random.Range(rht1, rht2)));
                    woodSum--;
                }
            }
        }
    }
}
