using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private bool canMove = false;

    private struct Direction // ���� ����
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
        // �̵� ����
        if (canMove)
        {
            // InputValue�� ���� �÷��̾� �̵�
            Vector2 input = value.Get<Vector2>();
            
            if(input != null) // input�� ���Է��϶��� ����
            {
                //�̵� �� �ش� �������� Rotation ����
                if (input.Equals(Vector2.up)) // ��
                {
                    transform.rotation = Direction.Up;
                }
                else if (input.Equals(Vector2.down)) // �Ʒ�
                {
                    transform.rotation = Direction.Down;
                }
                else if (input.Equals(Vector2.left)) // ��
                {
                    transform.rotation = Direction.Left;
                }
                else // ��
                {
                    transform.rotation = Direction.Right;
                }

                Debug.DrawRay(transform.position, transform.up * -1f, Color.red);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1);
                Debug.Log("hit : " + hit.collider.name + " ����!");
                if (hit.collider.CompareTag("UnMoveableObject"))
                {
                    // ����ĳ��Ʈ�� UnmoveableObject ���̾�� �浹�ϴ��� Ȯ���մϴ�.
                    Debug.Log("hit : " + hit.collider.name + " �浹 �߻�!");
                }
                else
                {
                    // �浹���� ������ �̵��մϴ�.
                    //���� �̵�
                    transform.position = transform.position + new Vector3(input.x, input.y, 0);
                }

                // �����ϸ� �ش� ���������� ������ ����.
                // �������� ������ �ش� �������� ������
            }
        }
    }
}
