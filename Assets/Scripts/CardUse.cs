using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(BoxCollider2D))]
public class CardUse : MonoBehaviour,IPointerDownHandler
{
    private Card card;

    private EnemyCtrl enemyCtrl;

    private BattleHUD enemyHUD;


    private GameObject cardUI;
    private void Awake()
    {
        card = Resources.Load<Card>("Prefabs/Cards/Fire");

        cardUI = GameObject.Find("Card");

        enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();

        enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        //card can only be used in player turn
        if (BattleSystem.instance.state != BattleState.PLAYERTURN) return;

        PlayerAttack();

        Destroy(cardUI);
    }
    
    private void PlayerAttack()
    {   
        Debug.Log("you choose attack");
        bool hpCheck = enemyCtrl.unit.TakeDamage(card.AttackPoint);

        enemyHUD.SetHP(enemyCtrl.unit.CurrentHp);

        if (hpCheck)
        {
            BattleSystem.instance.UpdateBattleState(BattleState.NEXTSTAGE);
            BattleSystem.instance.EndBattle(true);
        }
        else
        {
            BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);
        }
        

    }
}
