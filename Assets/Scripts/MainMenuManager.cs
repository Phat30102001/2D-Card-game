using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GameObject.Find("OptionMenu").GetComponent<Animator>();
    }
    private void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("MainMenuTheme");
        animator.SetBool("InGame", false);
    }
    private void SelectSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("Select");
    }
    public void HandlePlayButton()
    {
        // User can't use other button if option scene is open
        if (animator.GetBool("Option")) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SelectSound();
    }

    public void HandleQuitButton()
    {
        if (animator.GetBool("Option")) return;
        Debug.Log("Quit");
        SelectSound();
        Application.Quit();

    }
    
    public void HandleOptionButton()
    {
        if (animator.GetBool("Option")) return;
        //Debug.Log("Option");
        animator.SetBool("Option", true);
        SelectSound();

    }
}
