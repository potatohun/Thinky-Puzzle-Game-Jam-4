using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveableObject : MonoBehaviour
{
    [SerializeField]
    [Header("오브젝트 움직임 가능")]
    private bool canMove = false;

    [SerializeField]
    [Header("오브젝트 정면 방향")]
    private Vector2 frontVector;

    [SerializeField]
    [Header("초기화 위치 정면 방향")]
    private Vector3 initialPosition;

    private void Awake()
    {
        canMove = true;
        frontVector = Vector2.down;
        initialPosition = this.transform.position;
    }

    public void ResetPosition()
    {
        // 위치 초기화
        this.transform.position = initialPosition;
    }

    public void Move(Vector2 vector)
    {
        //이동 전 해당 방향으로 Rotation 변경
        Rotate(vector);
        canMove = true; // canMove 초기화

        // 돌리고 앞에 장애물 있는지 확인!
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, frontVector, 1f);

        foreach (RaycastHit2D hit in hits)
        {
            if ((hit.collider != null)&&(hit.collider.gameObject!=this.gameObject))
            {
                if (hit.collider.CompareTag("UnMoveableObject") || hit.collider.CompareTag("Flag")|| hit.collider.CompareTag("MoveableObject")) // 장애물 존재시 canMove = false
                {
                    Debug.Log("UnMoveableObject 감지!!");
                    canMove = false;
                }
            }
        }

        if (canMove) // 장애물 없을 경우 true
        {
            //실제 이동
            transform.position = transform.position + new Vector3(vector.x, vector.y, 0);
        }
    }

    void Rotate(Vector2 input) // 플레이어 방향 바꾸는 함수
    {
        if (input.Equals(Vector2.up)) // 위
        {
            frontVector = Vector2.up;
        }
        else if (input.Equals(Vector2.down)) // 아래
        {
            frontVector = Vector2.down;
        }
        else if (input.Equals(Vector2.left)) // 좌
        {
            frontVector = Vector2.left;
        }
        else // 우
        {
            frontVector = Vector2.right;
        }
    }
}
