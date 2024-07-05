using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Header("플레이어 움직임 가능")]
    private bool canMove = false;

    [SerializeField]
    [Header("플레이어 정면 방향")]
    private Vector2 frontVector;

    [SerializeField]
    [Header("플레이어 MOVE 효과음")]
    private AudioSource moveSound;
    [SerializeField]
    [Header("플레이어 PUSH 효과음")]
    private AudioSource pushSound;

    private struct Direction // 방향 정의
    {
        public static readonly Quaternion Up = Quaternion.Euler(0, 0, 180);
        public static readonly Quaternion Down = Quaternion.Euler(0, 0, 0);
        public static readonly Quaternion Left = Quaternion.Euler(0, 0, 270);
        public static readonly Quaternion Right = Quaternion.Euler(0, 0, 90);
    }

    private void Start()
    {
        canMove = true;
        frontVector = Vector2.down;
    }

    public void ResetPosition(Vector3 vector3) 
    {
        // 플레이어 위치 초기화 및 회전 방향 초기화
        transform.position = vector3;
        frontVector = Vector2.down;
        RotatePlayer(frontVector);
    }

    public void OnMove(InputValue value)
    {
        // InputValue에 따라 플레이어 이동
        Vector2 input = value.Get<Vector2>();

        if (input != null) // input의 정입력일때만 실행
        {
            Move(input);
        }
    }
    public void Move(Vector2 vector)
    {
        //이동 전 해당 방향으로 Rotation 변경
        RotatePlayer(vector);
        canMove = true; // canMove 초기화

        // 돌리고 앞에 장애물 있는지 확인!
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, frontVector, 1f);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("UnMoveableObject")) // 장애물 존재시 canMove = false
                {
                    Debug.Log("UnMoveableObject 감지!!");
                    canMove = false;
                }
                else if (hit.collider.CompareTag("MoveableObject"))
                {
                    // MoveableObject 밀기!
                    pushSound.Play();
                    hit.collider.GetComponent<MoveableObject>().Move(vector); // push 함수 실행!
                    Debug.Log("MoveableObject 감지!!");
                    canMove = false;
                }
            }
        }

        if (canMove) // 장애물 없을 경우 true
        {
            //실제 이동
            transform.position = transform.position + new Vector3(vector.x, vector.y, 0);
            moveSound.Play();
        }
    }

    void RotatePlayer(Vector2 input) // 플레이어 방향 바꾸는 함수
    {
        if (input.Equals(Vector2.up)) // 위
        {
            transform.rotation = Direction.Up;
            frontVector = Vector2.up;
        }
        else if (input.Equals(Vector2.down)) // 아래
        {
            transform.rotation = Direction.Down;
            frontVector = Vector2.down;
        }
        else if (input.Equals(Vector2.left)) // 좌
        {
            transform.rotation = Direction.Left;
            frontVector = Vector2.left;
        }
        else // 우
        {
            transform.rotation = Direction.Right;
            frontVector = Vector2.right;
        }
    }
}
