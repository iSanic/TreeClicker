using UnityEngine;

//������������ ��� ������ ���� ������ - ��� ���������� ������ ����������� �� ����� ��� �������
public class CercleBar : MonoBehaviour
{
    public Transform Player;
    void FixedUpdate()
    {
        this.transform.position = Player.transform.position + new Vector3(0, 1f, 0);
    }
}
