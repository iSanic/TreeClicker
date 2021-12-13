using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Move_Player : MonoBehaviour
{
    //��, ��� �������� � �������
    public Click_manager cm;
    public Tree tree;
    public BoxCollider2D TreeBC;
    
    //������� ������� ������
    public TriggerRL trigRL;

    //�������� ������
    public Animation Axe;

    //�������� �����������
    public GameObject SercleBar;


    //��������� ����������� ������� ���� 
    BoxCollider2D bc;
    Rigidbody2D rb;
    public float speed = 0.2f;
    Vector2 pos = new Vector2(0f, 0f);
    public Vector3 mousePos;

    //�������� ����������� ������� ������
    bool faceRight = true;
    public float reload;


    //�������� ����������� ������� ����
    private bool clickToPlayer = false;
    [SerializeField]
    private bool btON = false;


    //!!!������ � ������� ��������� ������ ������� ����
    public int[] woodIndex;

    //�����
    public AudioSource HitToTree;
    public AudioSource WoddUp;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        checkMove();
        checkBT();
    }

    //������� ��������� ������ � ����������� ������ ������
    void Reflect(Vector2 mousePos, Vector2 pos)
    {
        if ((mousePos.x > pos.x && !faceRight) || mousePos.x < pos.x && faceRight)
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
        if (faceRight) 
        {
            cm.rht1 = 0;
            cm.rht2 = 60;
        }
        if (!faceRight)
        {
            cm.rht1 = -270;
            cm.rht2 = -180;
        }
    }

    //���� ���� ������ �� ������ - ������ �������� �� ������� 
    public void checkMove()
    {
        
        if (clickToPlayer == true)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector2 posX = new Vector2(mousePos.x, -3.5f);

            pos = Vector2.Lerp(transform.position, posX, speed);

            rb.MovePosition(pos);
            Reflect(mousePos, pos);
        }
    }

    //���� ����� � ������ - ����� �������� �� ������ 
    public void checkBT()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (btON == true) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (tree.bc == Physics2D.OverlapPoint(pos))
                {
                    StartCoroutine(Reload());
                }
            }
        }
    }


    //�������� ��� ����������� ����� � ������������
    public IEnumerator Reload()
    {
        HitToTree.pitch = Random.Range(0.9f, 1.3f);                     //������������� ���� ����� �� ������ �������
        HitToTree.Play();

        Axe.Play("AxeDown");                                            //��������� �������� ����� ������

        cm.clickTree();                                                 //�������� �� ����� ������ ����� ����� �� ������
        TreeBC.enabled = false;
        SercleBar.GetComponent<Image>().enabled = true;
        while (SercleBar.GetComponent<Image>().fillAmount != 0)         //���� �������� �� ����������� - ������ �� ������ ������
        {
            SercleBar.GetComponent<Image>().fillAmount -= 0.1f;
            yield return new WaitForSeconds(reload);
        }
        SercleBar.GetComponent<Image>().enabled = false;                //����� ��������� �������� - ����� ������������� � �������� ���������
        SercleBar.GetComponent<Image>().fillAmount = 1f;
        TreeBC.enabled = (true);
        Axe.Play("AxeUp");
    }


    //��� ������� �� ���� - �������� ��������
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 poss = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (bc == Physics2D.OverlapPoint(poss))
            {

                clickToPlayer = true;
            }
        }
    }
    private void OnMouseUp()
    {
        clickToPlayer = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���� ����� � ������ - ������ �������
        if (collision.gameObject.name.Equals("Tree"))
        {
            btON = true;
        }

        //���� ����� ������� � ������ - ��������� ���
        if (collision.gameObject.name.Equals("Wood0(Clone)"))
        {
            Destroy(collision.gameObject);
            woodIndex[0] += 1;
            WoddUp.Play();
        }
        if (collision.gameObject.name.Equals("Wood1(Clone)"))
        {
            Destroy(collision.gameObject);
            woodIndex[1] += 1;
            WoddUp.Play();
        }


        //�������� ������ Sale/Market
        if (collision.gameObject.name.Equals("TriggerL"))
        {
            trigRL.TriggLeftON();
        }
        if (collision.gameObject.name.Equals("TriggerR"))
        {
            trigRL.TriggRightON();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //���� ����� �� � ������ - �� ������ ������ ������
        if (collision.gameObject.name.Equals("Tree"))
        {
            btON = false;
        }


        //������ Sale/Market ��������� ��� ������ �� ��������
        if (collision.gameObject.name.Equals("TriggerL"))
        {
            trigRL.TriggLeftOFF();
        }
        if (collision.gameObject.name.Equals("TriggerR"))
        {
            trigRL.TriggRightOFF();
        }
    }
}