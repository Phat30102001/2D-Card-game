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

    public void Action()
    {
        System.Random random = new System.Random();

        //random choice, healing have lower chance
        int choice= random.Next(0,5);

        switch (choice)
        {
            case 0:
                StartCoroutine(Heal());
                break;
                

            default:
                StartCoroutine(NormalAttack());
                break;
        }
    }

    private IEnumerator NormalAttack()
    {
        yield return new WaitForSeconds(1f);

        DotweenAnimateEffect.instance.AttackAnimation(enemyPrefab, playerPrefab,false);

        System.Random random = new System.Random();

        int dmg = random.Next(enemyCtrl.unit.Damage-1, enemyCtrl.unit.Damage+2);

        FindObjectOfType<AudioManager>().PlaySound("EnemyAttack");

        FindObjectOfType<MessageNotify>().ShowMessage("Enemy use Normal attack. You take " + dmg + " damage");

        bool hpCheck= playerCtrl.unit.TakeDamage(dmg);

        playerHUD.SetHP(playerCtrl.unit.CurrentHp);

        yield return new WaitForSeconds(1f);

        if (hpCheck)
        {
            FindObjectOfType<AudioManager>().PlaySound("Death");
            BattleSystem.instance.UpdateBattleState(BattleState.LOSE);
        }
        else
        {
            CardSpawner.instance.HandleSpawnCard();
            BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
        }
    }

    private IEnumerator Heal()
    {
        yield return new WaitForSeconds(1f);
        
        enemyCtrl.unit.Healpoint(3);

        FindObjectOfType<AudioManager>().PlaySound("Heal");
        FindObjectOfType<MessageNotify>().ShowMessage("Enemy use Heal");

        enemyHUD.SetHP(enemyCtrl.unit.CurrentHp);
        DotweenAnimateEffect.instance.HealAnimation(enemyPrefab);

        yield return new WaitForSeconds(1f);
        CardSpawner.instance.HandleSpawnCard();
        BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
    }
}
