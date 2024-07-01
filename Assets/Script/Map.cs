using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    [Header("�÷��̾� ���� ��ġ")]
    private Vector3 playerStartPosition;

    [SerializeField]
    [Header("MoveableObject ����Ʈ")]
    private List<MoveableObject> moveableObjects;
    
    public void ResetMoveableObjects()
    {
        foreach (var moveableObject in moveableObjects)
        {
            moveableObject.ResetPosition();
        }
    }

    public Vector3 ReturnplayerStartPosition()
    {
        return playerStartPosition;
    }
}
