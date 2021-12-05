using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRL : MonoBehaviour
{
    public Animation Right;
    public Animation Left;


    public void TriggRightON()
    {
        Right.Play("R_up");
    }

    public void TriggLeftON()
    {
        Left.Play("L_up");
    }
    public void TriggRightOFF()
    {
        Right.Play("R_down");
    }

    public void TriggLeftOFF()
    {
        Left.Play("L_down");
    }

}
