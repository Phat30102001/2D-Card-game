using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuManager : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GameObject.Find("OptionMenu").GetComponent<Animator>();
    }
    public void HandleBackButton()
    {
        animator.SetBool("Option", false);
    }
}
