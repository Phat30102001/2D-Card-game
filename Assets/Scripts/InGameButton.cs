using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButton : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GameObject.Find("OptionMenu").GetComponent<Animator>();
    }
    private void Start()
    {
        animator.SetBool("InGame", true);
    }
    public void HandleOptionButton()
    {
        if (animator.GetBool("Option")||BattleSystem.instance.state==BattleState.LOSE) return;
        //Debug.Log("Option");
        animator.SetBool("Option", true);
        FindObjectOfType<AudioManager>().PlaySound("Select");

    }
}
