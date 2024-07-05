using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    [SerializeField]
    private FadeInOut fadeInOut;
    private bool isPlayingFadeInOut = false;

    [SerializeField]
    [Header("시작 효과음")]
    private AudioSource startSound;

    private void OnEnable()
    {
        fadeInOut.FadeIn();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPlayingFadeInOut)
            {
                startSound.Play();
                isPlayingFadeInOut = true;
                fadeInOut.FadeOut();
                Invoke("LoadStart", 1.5f);
            }
        }
    }

    void LoadStart()
    {
        Destroy(GameManager.gamemanager.gameObject);
        Destroy(Music.instance.gameObject);
        fadeInOut.FadeIn();
        SceneManager.LoadScene("Start");
    }
}
