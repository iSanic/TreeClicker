using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Percs : MonoBehaviour
{
    public GameObject percPanel;

    public Text Name;
    public Text Info;
    public Text Count;


    public int[] coutIndex = {
        100,                    //Выносливость
        1000,                   //Сила
        6000, 9000, 10000,      //Точность (крит)
        12000, 15000, 50000     //Второе дыхание (Второй удар)
    };

    private void Start()
    {
        HidePanel();
    }
    public void HidePanel()
    {
        percPanel.SetActive(false);
    }



    public void Stamina()
    {
        percPanel.SetActive(true);

        Name.text = "Stamina";
        Info.text = "Increases mining speed";
        Count.text = coutIndex[0] + "$";
    }



    public void Power()
    {
        percPanel.SetActive(true);

        Name.text = "Power";
        Info.text = "Increases the chance of falling out of deeper and more expensive layers of wood";
        Count.text = coutIndex[1] + "$";
    }



    public void Accuracy()
    {
        percPanel.SetActive(true);

        Name.text = "Accuracy";
        Info.text = "Critical strike ability";
        Count.text = coutIndex[2] + "$";
    }
    public void Mastery()
    {
        percPanel.SetActive(true);

        Name.text = "Mastery";
        Info.text = "Increases critical hit chance";
        Count.text = coutIndex[3] + "$";
    }
    public void Rage()
    {
        percPanel.SetActive(true);

        Name.text = "Rage";
        Info.text = "Increases critical strike power";
        Count.text = coutIndex[4] + "$";
    }



    public void SecondWind()
    {
        percPanel.SetActive(true);

        Name.text = "Second wind";
        Info.text = "There is a chance to make a second hit immediately after the first";
        Count.text = coutIndex[5] + "$";
    }
    public void EvenBreathing()
    {
        percPanel.SetActive(true);

        Name.text = "Second wind";
        Info.text = "Increases second hit chance";
        Count.text = coutIndex[6] + "$";
    }
    public void DeepBreath()
    {
        percPanel.SetActive(true);

        Name.text = "Deep breath";
        Info.text = "Increases the number of hits";
        Count.text = coutIndex[7] + "$";

    }
}
