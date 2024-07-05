using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager; // 싱글톤

    [SerializeField]
    private FadeInOut fadeInOut;
    private bool isPlayingFadeInOut;

    [SerializeField]
    [Header("플레이어")]
    private PlayerMovement Player;

    [SerializeField]
    [Header("맵 리스트")]
    private List<Map> maps;

    [SerializeField]
    [Header("맵 리스트")]
    private int currentMapIndex;
    private bool isClear;

    [SerializeField]
    [Header("클리어 효과음")]
    private AudioSource clearSound;

    public Text levelText;
    public GameObject GameClearPanel;

    private void Awake()
    {
        if (null == gamemanager) // 싱글톤 
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
        if (Input.GetKeyDown(KeyCode.R)) // R 누르면 리셋
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
        maps[currentMapIndex].gameObject.SetActive(false); // 현재 맵 비활성화

        if (isClear) // 클리어 후 초기화 일 경우
        {
            currentMapIndex++; // 인덱스 증가
            isClear = false;
        }

        // 실제 맵 초기화 부분
        Player.ResetPosition(maps[currentMapIndex].ReturnplayerStartPosition()); // 플레이어 위치 초기화
        maps[currentMapIndex].ResetMoveableObjects(); // MoveableObject 위치 초기화

        fadeInOut.FadeIn();
        isPlayingFadeInOut = false;

        levelText.text = "LEVEL " + (maps[currentMapIndex].ReturnMapNumber()).ToString(); // 레벨 텍스트 변경
        maps[currentMapIndex].gameObject.SetActive(true); // 다음 맵 활성화 or 초기화 맵 활성화
    }

    public void ClearMap()
    {
        clearSound.Play();

        isClear = true;
        isPlayingFadeInOut = true;
        fadeInOut.FadeOut(); // 페이드 아웃

        if(currentMapIndex + 1 < maps.Count) // 다음 maps가 있으면 다음 맵으로 이동
        {
            Invoke("ResetMap", 1.5f); // 페이드 인
        }
        else // 없으면
        {
            // 최종 종료!
            Invoke("ClearGame", 1.5f); // 페이드 인
        }
    }

    void ClearGame()
    {
        Player.gameObject.SetActive(false);
        maps[currentMapIndex].gameObject.SetActive(false);
        GameClearPanel.SetActive(true);
    }
}