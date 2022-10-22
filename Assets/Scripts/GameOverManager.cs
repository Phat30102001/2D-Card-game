using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
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

    public void HandleRestartButton()
    {
        if (BattleSystem.instance.state != BattleState.LOSE) return;

        FindObjectOfType<AudioManager>().PlaySound("Select");
        gameObject.SetActive(false);
        cardDestroy.DestroyAllCard();
        BattleSystem.instance.UpdateBattleState(BattleState.START);
    }
    public void HandleBackMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
