using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMarket : MonoBehaviour
{
    public Text SwText;
    bool flag = true;

    public GameObject TreeUpdate;
    public GameObject AxeMarket;
    public AudioSource Button;

    private void Update()
    {
        if (flag)
        {
            TreeUpdate.SetActive(true);
            AxeMarket.SetActive(false);
            SwText.text = "Axe";
        }
        else
        {
            TreeUpdate.SetActive(false);
            AxeMarket.SetActive(true);
            SwText.text = "Upgrade";
        }
    }

    public void switchMarket()
    {
        Button.Play();
        flag = !flag;
    }
}
