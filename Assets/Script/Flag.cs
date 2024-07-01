using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어 감지
        {
            Debug.Log("종료!");
            this.enabled = false;
            GameManager.gamemanager.ClearMap();
        }
    }
}
