using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private EnemySkill enemySkill;
    public Unit unit;
    void Awake()
    {
        enemySkill = GameObject.Find("EnemyPrefab").GetComponent<EnemySkill>();
        


        unit.Damage = 3;
        unit.MaxHp = 9;
        unit.CurrentHp = unit.MaxHp;
        unit.Element = "ice";
    }
    public void HandleEnemyTurn()
    {
        
        enemySkill.Action();
        
    }


    
}
