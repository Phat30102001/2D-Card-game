using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Unit unit;

    private EnemyCtrl enemyCtrl;
    
    private BattleHUD enemyHUD;


    // Start is called before the first frame update
    void Awake()
    {
        unit = Resources.Load<Unit>("Prefabs/Player");


        //unit.Damage = 3;
        unit.MaxHp = 50;
        unit.CurrentHp = unit.MaxHp;
        unit.Element = "none";


        enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();

        enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();

    }
    /*public void OnAttackButton()
    {
        if (BattleSystem.instance.state != BattleState.PLAYERTURN) return;

        PlayerAttack();
        
    }*/
    /*private void PlayerAttack()
    {   
        Debug.Log("you choose attack");
        bool hpCheck = enemyCtrl.unit.TakeDamage(unit.Damage);

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
        

    }*/

}
