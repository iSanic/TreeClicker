using UnityEngine;

//Единственное что делает этот скрипт - это перемещать кружок перезарядки всё время над игроком
public class CercleBar : MonoBehaviour
{
    public Transform Player;
    void FixedUpdate()
    {
        this.transform.position = Player.transform.position + new Vector3(0, 0.6f, 0);
    }
}
