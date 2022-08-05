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
    private CardSpawner cardSpawner;
    // 3 cards have been spawned when game started, so the next time card spawn will be the 4th one
    int i = 3;



    // Singleton
    private void Awake()
    {
        stageGenerate = GameObject.Find("Stage").GetComponent<StageGenerate>();
        enemyCtrl= GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();
        turnNotify= GetComponent<TurnNotify>();
        

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
                break;
            case BattleState.LOSE:
                break;
            case BattleState.DRAWCARD:
                cardSpawner.Spawn(i);
                break;
        }
    }

    

    /*private IEnumerator SetUpBattle()
    {
        GameObject playerGO= Instantiate(playerPrefab, playerBattleStation);
        playerUnit =playerGO.GetComponent<Unit>();

        GameObject enemyGO= Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        Debug.Log("Battle start");

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        //state = BattleState.PLAYERTURN;
        UpdateBattleState(BattleState.PLAYERTURN);
    }*/

   /* private void PlayerTurn()
    {
        
    }*/

    /*public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());
        Debug.Log("you choose attack");
    }

    private IEnumerator PlayerAttack()
    {
        bool hpCheck= enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHp);

        yield return new WaitForSeconds(2f);

        if (hpCheck)
        {
            state = BattleState.DECIDE;
            EndBattle(true);
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine( EnemyTurn());
        }
    
    }*/

    

    public void EndBattle(bool decision)
    {
        if (decision==true) Debug.Log("Win");
        if (decision==false) Debug.Log("Lose");
    }
}
