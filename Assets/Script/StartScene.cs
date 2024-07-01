using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public FadeInOut fadeInOut;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) // Enter �Է� ���� �� ���ӽ���!
        {
            fadeInOut.FadeOut();
            Invoke("LoadGameScene", 1.5f);
        }
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
