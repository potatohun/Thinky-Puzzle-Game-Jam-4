using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveableObject : MonoBehaviour
{
    [SerializeField]
    [Header("�÷��̾� ������ ����")]
    private bool canMove = false;

    [SerializeField]
    [Header("�÷��̾� ���� ����")]
    private Vector2 frontVector;

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
        frontVector = Vector2.down;
    }

    public void Move(Vector2 vector)
    {
        //�̵� �� �ش� �������� Rotation ����
        RotatePlayer(vector);
        canMove = true; // canMove �ʱ�ȭ

        // ������ �տ� ��ֹ� �ִ��� Ȯ��!
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, frontVector, 1f);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("UnMoveableObject")) // ��ֹ� ����� canMove = false
                {
                    Debug.Log("UnMoveableObject ����!!");
                    canMove = false;
                }
                else if (hit.collider.CompareTag("MoveableObject"))
                {
                    // MoveableObject �б�!
                    hit.collider.GetComponent<MoveableObject>(); // push �Լ� ����!
                    Debug.Log("MoveableObject ����!!");
                    canMove = false;
                }
            }
        }

        if (canMove) // ��ֹ� ���� ��� true
        {
            //���� �̵�
            transform.position = transform.position + new Vector3(vector.x, vector.y, 0);
        }
    }

    void RotatePlayer(Vector2 input) // �÷��̾� ���� �ٲٴ� �Լ�
    {
        if (input.Equals(Vector2.up)) // ��
        {
            transform.rotation = Direction.Up;
            frontVector = Vector2.up;
        }
        else if (input.Equals(Vector2.down)) // �Ʒ�
        {
            transform.rotation = Direction.Down;
            frontVector = Vector2.down;
        }
        else if (input.Equals(Vector2.left)) // ��
        {
            transform.rotation = Direction.Left;
            frontVector = Vector2.left;
        }
        else // ��
        {
            transform.rotation = Direction.Right;
            frontVector = Vector2.right;
        }
    }
}
