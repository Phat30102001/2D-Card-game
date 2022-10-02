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

    private CardDestroy cardDestroy;

    [SerializeField] private CardInfo cardInfo;

    private void Awake()
    {
        playerCtrl = GameObject.Find("PlayerCtrl").GetComponent<PlayerCtrl>();

        cardInfo = GetComponent<CardInfo>();

        enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();

        enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();
        playerHUD = GameObject.Find("PlayerHealthBar").GetComponent<BattleHUD>();

        playerPrefab = GameObject.Find("PlayerPrefab");
        enemyPrefab = GameObject.Find("EnemyPrefab");

        cardDestroy = GameObject.Find("CardOnHand").GetComponent<CardDestroy>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        //card can only be used in player turn
        if (BattleSystem.instance.state != BattleState.PLAYERTURN) return;
        
        // right click to discard, sacrifice 1 hp
        if (Input.GetMouseButtonDown(1))
        {
            FindObjectOfType<AudioManager>().PlaySound("Discard");

            FindObjectOfType<MessageNotify>().ShowMessage("You discarded a card");

            cardDestroy.DestroyCard(gameObject);
            BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);
        }

        // left click to use card
        if (Input.GetMouseButtonDown(0))
        {
            if (cardInfo.cardName == "Heal") PlayerHeal();
            else
            {
                if(cardInfo.cardName == enemyCtrl.unit.Element) Penalty();
                else PlayerAttack();
            }
        }
    }
    
    private void PlayerAttack()
    {
        bool hpCheck = enemyCtrl.unit.TakeDamage(cardInfo.attackPoint);

        FindObjectOfType<AudioManager>().PlaySound("PlayerAttack");

        FindObjectOfType<MessageNotify>().ShowMessage("You deal " + cardInfo.attackPoint + " " + cardInfo.cardName + " damage");
        enemyHUD.SetHP(enemyCtrl.unit.CurrentHp);
        DotweenAnimateEffect.instance.AttackAnimation(playerPrefab,enemyPrefab,true);
        // check hp=0
        if (hpCheck)
        {
            FindObjectOfType<AudioManager>().PlaySound("Death");
            BattleSystem.instance.UpdateBattleState(BattleState.NEXTSTAGE);
        }
            

        else CheckElement();

        cardDestroy.DestroyCard(gameObject);
    }

    private void PlayerHeal()
    {
        playerCtrl.unit.Healpoint(cardInfo.healPoint);

        FindObjectOfType<AudioManager>().PlaySound("Heal");

        FindObjectOfType<MessageNotify>().ShowMessage("You restore "+ cardInfo.healPoint + " hp");

        playerHUD.SetHP(playerCtrl.unit.CurrentHp);

        DotweenAnimateEffect.instance.HealAnimation(playerPrefab);

        cardDestroy.DestroyCard(gameObject);

        BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);
    }

    private void Penalty()
    {
        // repel 3 damgage when penalty
        bool hpCheck = playerCtrl.unit.TakeDamage(3);

        FindObjectOfType<AudioManager>().PlaySound("RepelAttack");

        FindObjectOfType<MessageNotify>().ShowMessage("You take 4 damage because the spell repeled");

        playerHUD.SetHP(playerCtrl.unit.CurrentHp);

        DotweenAnimateEffect.instance.DamageRecieveAnimation(playerPrefab);

        if (hpCheck) 
        {
            FindObjectOfType<AudioManager>().PlaySound("Death");
            BattleSystem.instance.UpdateBattleState(BattleState.LOSE); 
        }
        else BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN);

        cardDestroy.DestroyCard(gameObject);
    }

    private void CheckElement()
    {
        if (cardInfo.cardName != enemyCtrl.unit.Weakness)
            BattleSystem.instance.UpdateBattleState(BattleState.ENEMYTURN); 
        else 
        {
            CardSpawner.instance.HandleSpawnCard();
            
            BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN); 
            FindObjectOfType<MessageNotify>().ShowMessage("You gain one more turn");
        }
    }

 
}
