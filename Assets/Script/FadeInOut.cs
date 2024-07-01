using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public Animator animatior;

    private void Start()
    {
        animatior = GetComponent<Animator>();

        animatior.SetTrigger("FadeIn");
    }
    public void FadeIn() // 페이드인
    {
        animatior.SetTrigger("FadeIn");
    }

    public void FadeOut() // 페이드 아웃
    {
        animatior.SetTrigger("FadeOut");
    }
}
