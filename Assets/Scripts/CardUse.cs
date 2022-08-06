using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(BoxCollider2D))]
public class CardUse : MonoBehaviour,IPointerDownHandler
{
    

    private EnemyCtrl enemyCtrl;

    private BattleHUD enemyHUD;

    //[SerializeField] private CardSpawner cardSpawner;


    //[SerializeField] private GameObject cardUI;

    [SerializeField] private CardInfo cardInfo;

    private void Awake()
    {
        //cardSpawner = GameObject.Find("CardInHand").GetComponent<CardSpawner>();

        //card = Resources.Load<Card>("Prefabs/Cards/Fire");



        cardInfo = GetComponent<CardInfo>();

        enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();

        enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();
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

        Debug.Log(enemyCtrl.unit.Element);

        if (cardInfo.cardName == enemyCtrl.unit.Element)
        {
            Debug.Log("Player deal 0 damage");

            BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);

            Destroy(gameObject);

            return;
        }

        PlayerAttack();

        
    }
    
    private void PlayerAttack()
    {   
        Debug.Log("you choose attack");

        bool hpCheck = enemyCtrl.unit.TakeDamage(cardInfo.attackPoint);

        Debug.Log("Player deal " + cardInfo.attackPoint + " " + cardInfo.cardName + " damage");
        enemyHUD.SetHP(enemyCtrl.unit.CurrentHp);

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

    private void CheckElement()
    {
        
        if (cardInfo.cardName != enemyCtrl.unit.Weakness) BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);
        else {
            CardSpawner.instance.HandleSpawnCard();
            BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN); 
        }
    }

}
