using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flowable: MonoBehaviour
{
    [SerializeField]
    [Header("플레이어 흐름 방향")]
    private Vector2 flowDirection;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어 감지
        {
            collision.gameObject.GetComponent<PlayerMovement>().Move(flowDirection); // 움직이기
        }

        if (collision.gameObject.CompareTag("MoveableObject")) // MoveableObject 감지
        {
            //collision.gameObject.GetComponent<MoveableObject>().Push(flowDirection); // 밀기
        }
    }
}
