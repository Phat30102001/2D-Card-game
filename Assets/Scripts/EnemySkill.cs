using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : MonoBehaviour
{
    private EnemyCtrl enemyCtrl;
    private PlayerCtrl playerCtrl;

    private BattleHUD enemyHUD;
    private BattleHUD playerHUD;

    private GameObject playerPrefab;
    private GameObject enemyPrefab;

    private void Awake()
    {
        enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();
        playerCtrl = GameObject.Find("PlayerCtrl").GetComponent<PlayerCtrl>();

        enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();
        playerHUD = GameObject.Find("PlayerHealthBar").GetComponent<BattleHUD>();

        playerPrefab = GameObject.Find("PlayerPrefab");
        enemyPrefab = GameObject.Find("EnemyPrefab");
    }

    public void Choice()
    {
        System.Random random = new System.Random();

        //random choice, healing have lower chance

        int choice= random.Next(0,5);
        //int choice= 1;
        StartCoroutine(Action(choice));
        //switch (choice)
        //{
        //    case 0:
        //        StartCoroutine(Heal());
        //        break;
                

        //    default:
        //        StartCoroutine(NormalAttack());
        //        break;
        //}
    }

    private IEnumerator Action(int choice)
    {
        yield return new WaitForSeconds(0.5f);
        switch (choice)
        {
            case 0:
                Heal();
                break;
            case 1:
                Debug.Log("unknow");
                ThrowUnknowCard();
                break;
            default:
                NormalAttack();
                break;
        }

        yield return new WaitForSeconds(1f);
    }

    private void NormalAttack()
    {
        //yield return new WaitForSeconds(1f);
        System.Random random = new System.Random();

        int dmg = random.Next(enemyCtrl.unit.Damage-1, enemyCtrl.unit.Damage+2);        

        bool hpCheck= playerCtrl.unit.TakeDamage(dmg);

        playerHUD.SetHP(playerCtrl.unit.CurrentHp);

        DotweenAnimateEffect.instance.AttackAnimation(enemyPrefab, playerPrefab,false);
        FindObjectOfType<AudioManager>().PlaySound("EnemyAttack");
        FindObjectOfType<MessageNotify>().ShowMessage("Enemy use Normal attack. You take " + dmg + " damage");
        //yield return new WaitForSeconds(1f);

        if (hpCheck)
        {
            FindObjectOfType<AudioManager>().PlaySound("Death");
            BattleSystem.instance.UpdateBattleState(BattleState.LOSE);
        }
        else
        {
            CardSpawner.instance.HandleSpawnCard(1);
            BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
        }
    }

    private void Heal()
    {
        //yield return new WaitForSeconds(1f);
        enemyCtrl.unit.Healpoint(3);

        enemyHUD.SetHP(enemyCtrl.unit.CurrentHp);

        DotweenAnimateEffect.instance.SpecialSkillAnimation(enemyPrefab);
        FindObjectOfType<AudioManager>().PlaySound("Heal");
        FindObjectOfType<MessageNotify>().ShowMessage("Enemy use Heal");

        //yield return new WaitForSeconds(1f);
        CardSpawner.instance.HandleSpawnCard(1);
        BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
    }

    private void ThrowUnknowCard()
    {
        if (LevelIncrease.instance.LevelCheck(1) == false)
        {
            Choice();
            return;
        }
        DotweenAnimateEffect.instance.SpecialSkillAnimation(enemyPrefab);
        FindObjectOfType<AudioManager>().PlaySound("Blind");
        FindObjectOfType<MessageNotify>().ShowMessage("Enemy use Blind, your next card will have unknow effect");

        CardSpawner.instance.HandleSpawnCard(2);
        BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
    }
}
