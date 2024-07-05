using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public FadeInOut fadeInOut;

    [SerializeField]
    [Header("���� ȿ����")]
    private AudioSource startSound;

    private void Start()
    {
        fadeInOut.FadeIn();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Enter �Է� ���� �� ���ӽ���!
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
