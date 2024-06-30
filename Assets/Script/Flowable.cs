using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flowable: MonoBehaviour
{
    [SerializeField]
    [Header("�÷��̾� �帧 ����")]
    private Vector2 flowDirection;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾� ����
        {
            collision.gameObject.GetComponent<PlayerMovement>().Move(flowDirection); // �����̱�
        }

        if (collision.gameObject.CompareTag("MoveableObject")) // MoveableObject ����
        {
            //collision.gameObject.GetComponent<MoveableObject>().Push(flowDirection); // �б�
        }
    }
}
