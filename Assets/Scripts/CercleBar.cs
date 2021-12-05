using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CercleBar : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Player.transform.position + new Vector3(0, 0.6f, 0);
    }
}
