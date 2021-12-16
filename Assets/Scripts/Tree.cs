using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [HideInInspector] public BoxCollider2D bc;
    public Move_Player mp;

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

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name.Equals("WoodPoint")) mp.btON = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("WoodPoint")) mp.btON = false;
    }

}
