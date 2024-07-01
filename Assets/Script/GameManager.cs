using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager; // �̱���

    [SerializeField]
    private FadeInOut fadeInOut;
    private bool isPlayingFadeInOut;

    [SerializeField]
    [Header("�÷��̾�")]
    private PlayerMovement Player;

    [SerializeField]
    [Header("�� ����Ʈ")]
    private List<Map> maps;

    [SerializeField]
    [Header("�� ����Ʈ")]
    private int currentMapIndex;
    private bool isClear;


    public Text levelText;
    public GameObject GameClearPanel;

    private void Awake()
    {
        if (null == gamemanager) // �̱��� 
        {
            gamemanager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        fadeInOut.FadeIn();
        isPlayingFadeInOut = false;
        currentMapIndex = 0;
        isClear = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // R ������ ����
        {
            if (!isPlayingFadeInOut)
            {
                isPlayingFadeInOut = true;
                fadeInOut.FadeOut();
                Invoke("ResetMap", 1.5f);
            }
        }
    }

    void ResetMap()
    {
        maps[currentMapIndex].gameObject.SetActive(false); // ���� �� ��Ȱ��ȭ

        // ���� �� �ʱ�ȭ �κ�
        Player.ResetPosition(maps[currentMapIndex].ReturnplayerStartPosition()); // �÷��̾� ��ġ �ʱ�ȭ
        maps[currentMapIndex].ResetMoveableObjects(); // MoveableObject ��ġ �ʱ�ȭ
        levelText.text = "LEVEL " + (currentMapIndex + 1).ToString(); // ���� �ؽ�Ʈ ����

        fadeInOut.FadeIn();
        isPlayingFadeInOut = false;

        if (isClear) // Ŭ���� �� �ʱ�ȭ �� ���
        {
            currentMapIndex++; // �ε��� ����
            isClear = false;
        }

        maps[currentMapIndex].gameObject.SetActive(true); // ���� �� Ȱ��ȭ or �ʱ�ȭ �� Ȱ��ȭ
    }

    public void ClearMap()
    {
        isClear = true;
        isPlayingFadeInOut = true;
        fadeInOut.FadeOut(); // ���̵� �ƿ�

        if(currentMapIndex + 1 < maps.Count) // ���� maps�� ������ ���� ������ �̵�
        {
            Invoke("ResetMap", 1.5f); // ���̵� ��
        }
        else // ������
        {
            // ���� ����!
            Player.gameObject.SetActive(false);
            maps[currentMapIndex].gameObject.SetActive(false);
            GameClearPanel.SetActive(true);
        }
        
    }
}