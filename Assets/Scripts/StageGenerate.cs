using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerate : MonoBehaviour
{
    
    
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerBattleStation;
    [SerializeField] private Transform enemyBattleStation;

    [SerializeField] private BattleHUD playerHUD;
    [SerializeField] private BattleHUD enemyHUD;

    [SerializeField] private Unit playerUnit;
    [SerializeField] private Unit enemyUnit;

    [SerializeField] private PlayerCtrl playerCtrl;
    [SerializeField] private EnemyCtrl enemyCtrl;

    GameObject tempBattleStation;

    private void Awake()
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy1");

        


        playerBattleStation = GameObject.Find("PlayerBattleStation").GetComponent<Transform>();
        enemyBattleStation = GameObject.Find("EnemyBattleStation").GetComponent<Transform>();


        System.Random random = new System.Random();

        int choice = random.Next(0, 10);

        playerHUD = GameObject.Find("PlayerHealthBar").GetComponent<BattleHUD>();
        enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();


        playerCtrl = GameObject.Find("PlayerCtrl").GetComponent<PlayerCtrl>();
        enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();
    }

    public IEnumerator SetUpBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        Debug.Log("Battle start");
        Debug.Log("enemy's element is " + enemyCtrl.unit.Element);

        playerHUD.SetHUD(playerCtrl.unit.MaxHp,playerCtrl.unit.CurrentHp);
        enemyHUD.SetHUD(enemyCtrl.unit.MaxHp,enemyCtrl.unit.CurrentHp);

        yield return new WaitForSeconds(2f);

        BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
        
    }

    public void HandleStageGen()
    {
        StartCoroutine(SetUpBattle());
    }

}
