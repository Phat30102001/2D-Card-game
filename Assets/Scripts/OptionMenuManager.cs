using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        FindObjectOfType<AudioManager>().PlaySound("Discard");
    }
    public void HandleBackMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
