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
    public void FadeIn() // ���̵���
    {
        animatior.SetTrigger("FadeIn");
    }

    public void FadeOut() // ���̵� �ƿ�
    {
        animatior.SetTrigger("FadeOut");
    }
}
