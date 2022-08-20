using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverManager : MonoBehaviour
{
    /*private void Awake()
    {
        gameObject.SetActive(false);
    }*/
    // Start is called before the first frame update


    // Update is called once per frame

    public TextMeshProUGUI score;
    public TextMeshProUGUI highestScore;

    private CardDestroy cardDestroy;

    private void Awake()
    {
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        highestScore = GameObject.Find("HighestScore").GetComponent<TextMeshProUGUI>();

        cardDestroy = GameObject.Find("CardOnHand").GetComponent<CardDestroy>();
    }

    public void GetScore(int floor,int deepestFloor)
    {
        if (BattleSystem.instance.state == BattleState.LOSE)
        {
            score.SetText("Floor: "+floor.ToString());
            highestScore.SetText("Deepest floor:"+deepestFloor.ToString());
        }
            
    }
    public void onClickEvent()
    {
        if (BattleSystem.instance.state != BattleState.LOSE) return;
        gameObject.SetActive(false);
        cardDestroy.DestroyAllCard();
        BattleSystem.instance.UpdateBattleState(BattleState.START);
    }
    
}
