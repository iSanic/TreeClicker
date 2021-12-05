using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [HideInInspector] public BoxCollider2D bc;


    public void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    public void offCol()
    {
        bc.enabled = false;
    }

    public void onCol()
    {
        bc.enabled = true;
    }

}
