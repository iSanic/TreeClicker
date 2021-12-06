using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] Transform FolowPos;
    [SerializeField, Range(-1f, 1f)] float paralaxSpeed;
    [SerializeField] bool disableVerticalParalax;
    Vector3 targetPos;

    void Start()
    {
        if (!FolowPos) FolowPos = Camera.main.transform;
        targetPos = FolowPos.position;
    }
    void FixedUpdate()
    {
        var delta = FolowPos.position - targetPos;
        if (disableVerticalParalax) delta.y = 0;

        transform.position = delta * paralaxSpeed;

    }
}
