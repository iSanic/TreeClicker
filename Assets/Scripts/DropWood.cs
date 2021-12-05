using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropWood : MonoBehaviour
{
    float Force;
    private Rigidbody2D rg;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Drop();
    }

    public void Drop()
    {
        Force = Random.Range(5, 10);
        rg.simulated = true;
        rg.AddForce(transform.right * Force, ForceMode2D.Impulse);
    }
}
