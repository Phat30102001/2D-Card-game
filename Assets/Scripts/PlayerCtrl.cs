using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Unit unit;

    //private Animator animator;

    //private EnemyCtrl enemyCtrl;
    
    //private BattleHUD enemyHUD;


    // Start is called before the first frame update
    void Awake()
    {
        unit = Resources.Load<Unit>("Prefabs/Player");




        //unit.Damage = 3;
        unit.MaxHp = 20;
        unit.CurrentHp = unit.MaxHp;
        unit.Element = "none";


        //enemyCtrl = GameObject.Find("EnemyCtrl").GetComponent<EnemyCtrl>();

       // enemyHUD = GameObject.Find("EnemyHealthBar").GetComponent<BattleHUD>();

    }
   

}
