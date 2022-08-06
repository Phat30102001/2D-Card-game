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
        System.Random random = new System.Random();


        playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        int enemyNum=random.Next(1,3);
        string enemyPath="Prefabs/Enemy"+enemyNum;
        enemyPrefab = Resources.Load<GameObject>(enemyPath);

        


        playerBattleStation = GameObject.Find("PlayerBattleStation").GetComponent<Transform>();
        enemyBattleStation = GameObject.Find("EnemyBattleStation").GetComponent<Transform>();


        

        //int choice = random.Next(0, 10);

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
        Debug.Log("enemy's weakness is " + enemyCtrl.unit.Weakness);
        Debug.Log("enemy's element is " + enemyCtrl.unit.Element);


        playerHUD.SetHUD(playerCtrl.unit.MaxHp,playerCtrl.unit.CurrentHp);
        enemyHUD.SetHUD(enemyCtrl.unit.MaxHp,enemyCtrl.unit.CurrentHp);

        yield return new WaitForSeconds(2f);

        BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);

        //Start the game with 3 card
        for(int i = 0; i < 3; i++)
        {
            CardSpawner.instance.HandleSpawnCard();
        }
        
    }
    

    public void HandleStageGen()
    {
        StartCoroutine(SetUpBattle());
    }

}
