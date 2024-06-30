using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private bool canMove = false;

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
    }
    private void Update()
    {
        
    }
    private void OnMove(InputValue value)
    {
        // 이동 가능
        if (canMove)
        {
            // InputValue에 따라 플레이어 이동
            Vector2 input = value.Get<Vector2>();
            
            if(input != null) // input의 정입력일때만 실행
            {
                //이동 전 해당 방향으로 Rotation 변경
                if (input.Equals(Vector2.up)) // 위
                {
                    transform.rotation = Direction.Up;
                }
                else if (input.Equals(Vector2.down)) // 아래
                {
                    transform.rotation = Direction.Down;
                }
                else if (input.Equals(Vector2.left)) // 좌
                {
                    transform.rotation = Direction.Left;
                }
                else // 우
                {
                    transform.rotation = Direction.Right;
                }

                Debug.DrawRay(transform.position, transform.up * -1f, Color.red);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1);
                Debug.Log("hit : " + hit.collider.name + " 감지!");
                if (hit.collider.CompareTag("UnMoveableObject"))
                {
                    // 레이캐스트가 UnmoveableObject 레이어와 충돌하는지 확인합니다.
                    Debug.Log("hit : " + hit.collider.name + " 충돌 발생!");
                }
                else
                {
                    // 충돌하지 않으면 이동합니다.
                    //실제 이동
                    transform.position = transform.position + new Vector3(input.x, input.y, 0);
                }

                // 존재하면 해당 방향으로의 움직임 제한.
                // 존재하지 않으면 해당 방향으로 움직임
            }
        }
    }
}
