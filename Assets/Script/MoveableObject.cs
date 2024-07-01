using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveableObject : MonoBehaviour
{
    [SerializeField]
    [Header("������Ʈ ������ ����")]
    private bool canMove = false;

    [SerializeField]
    [Header("������Ʈ ���� ����")]
    private Vector2 frontVector;

    [SerializeField]
    [Header("�ʱ�ȭ ��ġ ���� ����")]
    private Vector3 initialPosition;

    private void Awake()
    {
        canMove = true;
        frontVector = Vector2.down;
        initialPosition = this.transform.position;
    }

    public void ResetPosition()
    {
        // ��ġ �ʱ�ȭ
        this.transform.position = initialPosition;
    }

    public void Move(Vector2 vector)
    {
        //�̵� �� �ش� �������� Rotation ����
        Rotate(vector);
        canMove = true; // canMove �ʱ�ȭ

        // ������ �տ� ��ֹ� �ִ��� Ȯ��!
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, frontVector, 1f);

        foreach (RaycastHit2D hit in hits)
        {
            if ((hit.collider != null)&&(hit.collider.gameObject!=this.gameObject))
            {
                if (hit.collider.CompareTag("UnMoveableObject") || hit.collider.CompareTag("Flag")|| hit.collider.CompareTag("MoveableObject")) // ��ֹ� ����� canMove = false
                {
                    Debug.Log("UnMoveableObject ����!!");
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

    void Rotate(Vector2 input) // �÷��̾� ���� �ٲٴ� �Լ�
    {
        if (input.Equals(Vector2.up)) // ��
        {
            frontVector = Vector2.up;
        }
        else if (input.Equals(Vector2.down)) // �Ʒ�
        {
            frontVector = Vector2.down;
        }
        else if (input.Equals(Vector2.left)) // ��
        {
            frontVector = Vector2.left;
        }
        else // ��
        {
            frontVector = Vector2.right;
        }
    }
}
