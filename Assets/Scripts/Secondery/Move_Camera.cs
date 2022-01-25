using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Move_Camera : MonoBehaviour
{
    public GameObject leftBT;           //Левая кнопка переключения
    public GameObject rightBT;          //Правая кнопка переключения
    public GameObject backBTleft;       //Боковые кнопки движения в центр
    public GameObject backBTright;

    public BoxCollider2D bc;
    public float speed = 5f;

    public AudioSource audioButton;

    bool l;
    bool r;
    bool c;

    private void Start()
    {
        backBTleft.SetActive(false);
        backBTright.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (l)
        {
            Vector3 dop = new Vector3(-0.1f, 0, 0);
            Vector3 left = new Vector3 (-6, 0, -10);
            this.transform.position = Vector3.Lerp(transform.position, left + dop, speed * Time.deltaTime); //Делать плавное движение налево
            leftBT.SetActive(false);
            rightBT.SetActive(false);
            bc.enabled = false;
            backBTleft.SetActive(false);
            if (this.transform.position.x <= left.x)
            {
                backBTleft.SetActive(true);
                l = false;
            }
        }

        if (r)
        {
            Vector3 dop = new Vector3(0.1f, 0, 0);
            Vector3 right = new Vector3(6, 0, -10);
            this.transform.position = Vector3.Lerp(transform.position, right + dop, speed * Time.deltaTime); //Делать плавное движение направо
            leftBT.SetActive(false);
            rightBT.SetActive(false);
            bc.enabled = false;
            backBTright.SetActive(false);
            if (this.transform.position.x >= right.x)
            {
                backBTright.SetActive(true);
                r = false;
            }
        }

        if (c)
        {
            Vector3 center = Vector3.zero;
            this.transform.position = center + new Vector3 (0, 0, -10); //Переместить камеру в центр потому что ёбаный юнити не хочет плавно двигать его в центр адекватно.
            bc.enabled = true;
            if (this.transform.position.x == center.x)
            {
                rightBT.SetActive(true);
                leftBT.SetActive(true);
                c = false;
            }
        }

    }

    public void Left()
    {
        audioButton.Play();
        l = true;
    }
    public void Center()
    {
        audioButton.Play();
        c = true;
    }
    public void Rigit()
    {
        audioButton.Play();
        r = true;
    }
}
