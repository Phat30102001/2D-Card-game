using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBoard : MonoBehaviour
{
    Animator animator;
    CanvasGroup canvas;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        canvas = GetComponent<CanvasGroup>();
        gameObject.SetActive(false);

    }
    public void HandleTutorialButton()
    {
        canvas.alpha = 0f;
        gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().PlaySound("Select");
        animator.SetBool("Tutorial", true);
    }
    public void HandleBackButton()
    {
        FindObjectOfType<AudioManager>().PlaySound("Discard");
        gameObject.SetActive(false);
    }
}
