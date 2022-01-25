using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject settingsPanel;

    public void panelOn()
    {
        settingsPanel.SetActive(true);
    }

    public void panelOff()
    {
        settingsPanel.SetActive(false);
    }
}
