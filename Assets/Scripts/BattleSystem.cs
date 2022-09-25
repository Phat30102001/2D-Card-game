using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START,PLAYERTURN,ENEMYTURN,NEXTSTAGE,LOSE}

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;

    public BattleState state;

    private StageGenerate stageGenerate;
    private EnemyCtrl enemyCtrl;
    private TurnNotify turnNotify;
    private FloorCount floorCount;

    private GameObject gameOver;
    private GameOverManager gameOverManager;

    //count the floor clear
    int score = 0;
    int highestScore = 0;

    private void Awake()
    {
        stageGenerate = GameObject.Find("Stage").GetComponent<StageGenerate>();
        enemyCtrl= GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();
        turnNotify= GetComponent<TurnNotify>();

        floorCount = GetComponent<FloorCount>();

        gameOver = GameObject.Find("GameOver");
        gameOverManager = gameOver.GetComponent<GameOverManager>();

        //singleton
        instance = this;
    }
    private void Start()
    {
        gameOverManager.gameObject.SetActive(false);
        UpdateBattleState(BattleState.START);
    }
    public void UpdateBattleState(BattleState newState)
    {
        
        
        state = newState;

        switch (state)
        {
            case BattleState.START:
                stageGenerate.HandleStageGen(); 
                break;
            case BattleState.PLAYERTURN:
                turnNotify.HandleTurnNotify();
                Debug.Log("Choose your card");
                break;
            case BattleState.ENEMYTURN:
                turnNotify.HandleTurnNotify();
                enemyCtrl.HandleEnemyTurn();
                break;
            case BattleState.NEXTSTAGE:
                score++;
                floorCount.Count(score);
                stageGenerate.HandleNextStageGen();
                break;
            case BattleState.LOSE:
                StartCoroutine( HandleGameOver());
                break;
        }
    }
    private void UpdateHighestScore()
    {
        if (score > highestScore) highestScore = score;
    }

    private IEnumerator HandleGameOver()
    {
        if (BattleSystem.instance.state == BattleState.LOSE)
        {
            UpdateHighestScore();

            yield return new WaitForSeconds(2f);

            gameOver.SetActive(true);

            gameOverManager.GetScore(score, highestScore);

            score=0;

            floorCount.Count(score);
        }

    }
}
