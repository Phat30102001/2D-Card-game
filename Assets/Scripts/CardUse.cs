using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



[RequireComponent(typeof(BoxCollider2D))]
public class CardUse : MonoBehaviour,IPointerDownHandler
{
    private PlayerCtrl playerCtrl;
    private EnemyCtrl enemyCtrl;

    private BattleHUD enemyHUD;
    private BattleHUD playerHUD;

    private GameObject playerPrefab;
    private GameObject enemyPrefab;

    [SerializeField] private CardInfo cardInfo;

    private void Awake()
    {
        //cardSpawner = GameObject.Find("CardInHand").GetComponent<CardSpawner>();

        //card = Resources.Load<Card>("Prefabs/Cards/Fire");

        playerCtrl = GameObject.Find("PlayerCtrl").GetComponent<PlayerCtrl>();

        cardInfo = GetComponent<CardInfo>();

        enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();

        enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();
        playerHUD = GameObject.Find("PlayerHealthBar").GetComponent<BattleHUD>();

        playerPrefab = GameObject.Find("PlayerPrefab");
        enemyPrefab = GameObject.Find("EnemyPrefab");



    }


    private void Start()
    {
        

        //card = Resources.Load<Card>("Prefabs/Cards/Fire");

        //cardUI = GameObject.Find(cardSpawner.gameObjectName);

        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        //card can only be used in player turn
        if (BattleSystem.instance.state != BattleState.PLAYERTURN) return;

        //if(cardInfo.cardName=="Heal")


        /*if (cardInfo.cardName == enemyCtrl.unit.Element)
        {
            // repel 2 damgage when penalty
            bool hpCheck = playerCtrl.unit.TakeDamage(2);
            playerHUD.SetHP(playerCtrl.unit.CurrentHp);

            Debug.Log("Player take 2 damage because of penalty");

            BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);

            Destroy(gameObject);

            return;
        }*/
        if(cardInfo.cardName == "Heal")
        {
            PlayerHeal();
        }
        else
        {
            if(cardInfo.cardName == enemyCtrl.unit.Element) PenaltyCheck();
            else PlayerAttack();
        }


        

        

        
    }
    
    private void PlayerAttack()
    {

        Debug.Log("you choose attack");

        bool hpCheck = enemyCtrl.unit.TakeDamage(cardInfo.attackPoint);

        Debug.Log("Player deal " + cardInfo.attackPoint + " " + cardInfo.cardName + " damage");
        enemyHUD.SetHP(enemyCtrl.unit.CurrentHp);
        DotweenAnimateEffect.instance.AttackAnimation(playerPrefab,enemyPrefab,true);
        if (hpCheck)
        {
            BattleSystem.instance.UpdateBattleState(BattleState.NEXTSTAGE);
            BattleSystem.instance.EndBattle(true);
        }
        else
        {

            CheckElement();

        }

        Destroy(gameObject);

    }

    private void PlayerHeal()
    {

        Debug.Log("Player restore " + cardInfo.healPoint + " hp");

        playerCtrl.unit.Healpoint(cardInfo.healPoint);

        playerHUD.SetHP(playerCtrl.unit.CurrentHp);

        Destroy(gameObject);

        BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);
    }

    private void PenaltyCheck()
    {
        
        // repel 2 damgage when penalty
        bool hpCheck = playerCtrl.unit.TakeDamage(2);
        playerHUD.SetHP(playerCtrl.unit.CurrentHp);

        Debug.Log("Player take 2 damage because of penalty");

        if (hpCheck)
        {
            BattleSystem.instance.UpdateBattleState(BattleState.LOSE);
            BattleSystem.instance.EndBattle(false);
        }
        else BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);

        Destroy(gameObject);

        
    }

    private void CheckElement()
    {
        if (cardInfo.cardName != enemyCtrl.unit.Weakness) {
            BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);
        } 
        else {
            CardSpawner.instance.HandleSpawnCard();
            BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN); 
        }
    }

 
}
