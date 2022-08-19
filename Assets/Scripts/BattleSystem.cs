using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START,PLAYERTURN,ENEMYTURN,DRAWCARD,NEXTSTAGE,LOSE}


public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;

    public BattleState state;

    /*public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    Unit playerUnit;
    Unit enemyUnit;*/

    private StageGenerate stageGenerate;
    private EnemyCtrl enemyCtrl;
    private TurnNotify turnNotify;
    private FloorCount floorCount;


    //count the floor clear
    int count = 0;

    // Singleton
    private void Awake()
    {
        stageGenerate = GameObject.Find("Stage").GetComponent<StageGenerate>();
        enemyCtrl= GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();
        turnNotify= GetComponent<TurnNotify>();

        floorCount = GetComponent<FloorCount>();

        instance = this;
    }
    private void Start()
    {

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
                count++;
                floorCount.Count(count);
                stageGenerate.HandleNextStageGen();
                break;
            case BattleState.LOSE:

                break;
            /*case BattleState.DRAWCARD:
                cardSpawner.Spawn();
                break;*/
        }
    }
    public void EndBattle(bool decision)
    {
        if (decision==true) Debug.Log("Win");
        if (decision==false) Debug.Log("Lose");
    }
}
