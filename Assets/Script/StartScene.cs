using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public FadeInOut fadeInOut;

    [SerializeField]
    [Header("시작 효과음")]
    private AudioSource startSound;

    private void Start()
    {
        fadeInOut.FadeIn();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Enter 입력 받을 시 게임시작!
        {
            startSound.Play();
            fadeInOut.FadeOut();
            Invoke("LoadGameScene", 2f);
        }
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
