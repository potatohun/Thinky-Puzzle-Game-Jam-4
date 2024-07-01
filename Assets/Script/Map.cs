using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    [Header("플레이어 시작 위치")]
    private Vector3 playerStartPosition;

    [SerializeField]
    [Header("MoveableObject 리스트")]
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
