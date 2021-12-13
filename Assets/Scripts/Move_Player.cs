using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Move_Player : MonoBehaviour
{
    //Всё, что связанно с деревом
    public Click_manager cm;
    public Tree tree;
    public BoxCollider2D TreeBC;
    
    //Триггер боковых кнопок
    public TriggerRL trigRL;

    //Анимация топора
    public Animation Axe;

    //Кружочек перезарядки
    public GameObject SercleBar;


    //Триггервы фиксирующие позицию мыши 
    BoxCollider2D bc;
    Rigidbody2D rb;
    public float speed = 0.2f;
    Vector2 pos = new Vector2(0f, 0f);
    public Vector3 mousePos;

    //Триггеры фиксирующие поворот игрока
    bool faceRight = true;
    public float reload;


    //Триггеры фиксирующие нажатия мыши
    private bool clickToPlayer = false;
    [SerializeField]
    private bool btON = false;


    //!!!Массив в котором храняться бревна разного вида
    public int[] woodIndex;

    //Звуки
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

    //Функция разварота топора и направления полета бревен
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

    //Если мышь нажата на игроке - делать движение за мышькой 
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

    //Если игрок у дерева - можно нажимать на дерево 
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


    //Карутина для возможности удара с перезарядкой
    public IEnumerator Reload()
    {
        HitToTree.pitch = Random.Range(0.9f, 1.3f);                     //Воспроизвести звук удара по дереву топором
        HitToTree.Play();

        Axe.Play("AxeDown");                                            //Запустить анимацию удара топора

        cm.clickTree();                                                 //Добавить на сцену бревна после удала по дереву
        TreeBC.enabled = false;
        SercleBar.GetComponent<Image>().enabled = true;
        while (SercleBar.GetComponent<Image>().fillAmount != 0)         //Пока задержка не закончиться - нажать на дерево нельзя
        {
            SercleBar.GetComponent<Image>().fillAmount -= 0.1f;
            yield return new WaitForSeconds(reload);
        }
        SercleBar.GetComponent<Image>().enabled = false;                //После окончания задержки - топор возвращаеться в исходное состояние
        SercleBar.GetComponent<Image>().fillAmount = 1f;
        TreeBC.enabled = (true);
        Axe.Play("AxeUp");
    }


    //При нажатии на мышь - включить движение
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
        //Если игрок у дерева - кнопка активна
        if (collision.gameObject.name.Equals("Tree"))
        {
            btON = true;
        }

        //Если игрок подошел к бревну - подобрать его
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


        //Триггеры кнопок Sale/Market
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
        //Если игрок не у дерева - на дерево нажать нельзя
        if (collision.gameObject.name.Equals("Tree"))
        {
            btON = false;
        }


        //Кнопки Sale/Market проподают при выходе из триггера
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