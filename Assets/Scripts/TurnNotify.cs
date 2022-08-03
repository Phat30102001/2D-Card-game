using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TurnNotify : MonoBehaviour
{
    private TextMeshProUGUI turnName;

    // turn is a game object to show the turn in the game
    private GameObject turn;

    private void Awake()
    {
        turnName = GameObject.Find("Turn").GetComponent<TextMeshProUGUI>();
        turn = GameObject.Find("Turn");
    }
    private void Start()
    {
        turn.SetActive(false);
    }
    public void HandleTurnNotify()
    {
        turn.SetActive(true);
        if (BattleSystem.instance.state == BattleState.PLAYERTURN)
        {
            turnName.text = "Player turn";
        }
        if (BattleSystem.instance.state == BattleState.ENEMYTURN)
        {
            turnName.text = "Enemy turn";
        }
        
        
    }
    


}
