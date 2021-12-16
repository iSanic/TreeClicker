using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Click_manager : MonoBehaviour
{
    public GameObject[] wood;   //������ ��� ������� ���� ������

    public Transform woodPoint; //������� ����� ������ ����� ���� ������

    public GameObject AxeEffect;//������ ������ ������� �� ����� �� ������

    public Move_Player mp;
    public int woodscore = 0;   //����� ���������� ������
    public int score = 0;       //����� ���������� �����

    public Text scoreText;      //����� �����
    public Text woodscoreText;  //����� ��������� ������

    //���� �������� �� ����������� ������� ����� �������� ������
    [HideInInspector] public int rht1;
    [HideInInspector] public int rht2;

    [Header("�����")]
    public int[] scanseDrop = { 0, 3 };    //���� ��������� ������
    public int[] Number = { 3, 2 };  //���������� ������ ������� ����� �������
    public int[] enabledWood = { 0, 0 };   //����� �� �������� ������


    //������ ���� ��������� ����� �� �����
    private void Update()
    {
        scoreText.text = score + "$";
        woodscoreText.text = woodscore + " wood";
        int sum = 0;
        for (int i = 0; i < mp.woodIndex.Length; i++) sum += mp.woodIndex[i];
        woodscore = sum;
    }

    //�������� ������
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
