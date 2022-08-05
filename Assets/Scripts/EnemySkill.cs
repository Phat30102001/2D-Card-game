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


    private void Awake()
    {
        enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();
        playerCtrl = GameObject.Find("PlayerCtrl").GetComponent<PlayerCtrl>();

        enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();
        playerHUD = GameObject.Find("PlayerHealthBar").GetComponent<BattleHUD>();

    }

    public void Action()
    {
        //Debug.Log("Enemy turn");



        System.Random random = new System.Random();

        int choice= random.Next(0,2);
        //Debug.Log(choice);
        switch (choice)
        {
            case 0:
                StartCoroutine(NormalAttack());
                //IsDead();
                break;

            case 1:
                StartCoroutine(Heal());
                break;
        }
        

    }
    /*public void IsDead()
    {
        if (playerUnit.currentHp<=0)
        {
            BattleSystem.instance.UpdateBattleState(BattleState.DECIDE);
            
        }
        else
        {
            BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
        }
    }*/


    private IEnumerator NormalAttack()
    {
        yield return new WaitForSeconds(1f);

        System.Random random = new System.Random();

        int dmg = random.Next(enemyCtrl.unit.Damage-1, enemyCtrl.unit.Damage+2);

        bool hpCheck= playerCtrl.unit.TakeDamage(dmg);

        playerHUD.SetHP(playerCtrl.unit.CurrentHp);

        Debug.Log("Enemy use Normal attack");
        Debug.Log("Player take " + dmg+ " damage");


        yield return new WaitForSeconds(1f);

        if (hpCheck)
        {
            BattleSystem.instance.UpdateBattleState(BattleState.LOSE);
            BattleSystem.instance.EndBattle(false);
        }
        else
            CardSpawner.instance.Spawn();

            BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);

    }
    private IEnumerator Heal()
    {
        yield return new WaitForSeconds(1f);
        
        enemyCtrl.unit.Healpoint(3);

        enemyHUD.SetHP(enemyCtrl.unit.CurrentHp);

        Debug.Log("Enemy use Heal");

        yield return new WaitForSeconds(1f);

        CardSpawner.instance.Spawn();

        BattleSystem.instance.UpdateBattleState(BattleState.PLAYERTURN);
    }
}
