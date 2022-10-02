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

    GameObject enemyGO;
    GameObject playerGO;

    private void Awake()
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/Player");


        playerBattleStation = GameObject.Find("PlayerBattleStation").GetComponent<Transform>();
        enemyBattleStation = GameObject.Find("EnemyBattleStation").GetComponent<Transform>();

        playerHUD = GameObject.Find("PlayerHealthBar").GetComponent<BattleHUD>();
        enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();


        playerCtrl = GameObject.Find("PlayerCtrl").GetComponent<PlayerCtrl>();
        enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();
    }

    private IEnumerator PlayerSpawn()
    {
        if (playerGO != null) Destroy(playerGO);

        yield return new WaitForSeconds(1f);
        playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        playerCtrl.StatGen();

        playerHUD.SetHUD(playerCtrl.unit.MaxHp, playerCtrl.unit.CurrentHp);
        
        //Start the game with 3 card
        for (int i = 0; i < 5; i++)
        {
            CardSpawner.instance.HandleSpawnCard();
        }

        BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
    }

    private IEnumerator EnemySpawn()
    {
        System.Random random = new System.Random();
        int enemyNum = random.Next(1, 5);
        string enemyPath = "Prefabs/Enemy" + enemyNum;
        enemyPrefab = Resources.Load<GameObject>(enemyPath);
        
        enemyCtrl.StateGen();

        yield return new WaitForSeconds(1f);

        // destroy previous enemyGO
        if (enemyGO != null)
        {
            DotweenAnimateEffect.instance.HandleDeadObject(enemyGO);
            yield return new WaitForSeconds(1f);
            Destroy(enemyGO);
        }
        enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyGO.name = "Enemy";
        enemyUnit = enemyGO.GetComponent<Unit>();

        enemyHUD.SetHUD(enemyCtrl.unit.MaxHp, enemyCtrl.unit.CurrentHp);
    }

    public void HandleStageGen()
    {
        StartCoroutine(PlayerSpawn());
        StartCoroutine(EnemySpawn());
        FindObjectOfType<AudioManager>().PlaySound("GameTheme");
        FindObjectOfType<MessageNotify>().ShowMessage("What will you do?");
    }

    public void HandleNextStageGen()
    {
        StartCoroutine(EnemySpawn());
        CardSpawner.instance.HandleSpawnCard();
        BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
    }

}
