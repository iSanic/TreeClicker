using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPercs : MonoBehaviour
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

    public void percInfo(int Index)
    {
        switch (Index)
        {
            case 0:
                percPanel.SetActive(true);

                Name.text = "Stamina";
                Info.text = "Increases mining speed";
                Count.text = coutIndex[Index] + "$";
                break;
            case 1:
                percPanel.SetActive(true);

                Name.text = "Power";
                Info.text = "Increases the chance of falling out of deeper and more expensive layers of wood";
                Count.text = coutIndex[Index] + "$";
                break;
            case 2:
                percPanel.SetActive(true);
                Name.text = "Accuracy";
                Info.text = "Critical strike ability";
                Count.text = coutIndex[Index] + "$";
                break;
            case 3:
                percPanel.SetActive(true);
                Name.text = "Mastery";
                Info.text = "Increases critical hit chance";
                Count.text = coutIndex[Index] + "$";
                break;
            case 4:
                percPanel.SetActive(true);
                Name.text = "Rage";
                Info.text = "Increases critical strike power";
                Count.text = coutIndex[Index] + "$";
                break;
            case 5:
                percPanel.SetActive(true);
                Name.text = "Second wind";
                Info.text = "There is a chance to make a second hit immediately after the first";
                Count.text = coutIndex[Index] + "$";
                break;
            case 6:
                percPanel.SetActive(true);
                Name.text = "Second wind";
                Info.text = "Increases second hit chance";
                Count.text = coutIndex[Index] + "$";
                break;
            case 7:
                percPanel.SetActive(true);
                Name.text = "Deep breath";
                Info.text = "Increases the number of hits";
                Count.text = coutIndex[Index] + "$";
                break;
            default:
                percPanel.SetActive(true);

                Name.text = "???";
                Info.text = "???";
                Count.text = "???$";
                break;

        }
    }
}
