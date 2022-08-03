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

        System.Random random = new System.Random();


        unit.Damage = random.Next(2,4);
        unit.MaxHp = random.Next(4, 15);
        unit.CurrentHp = unit.MaxHp;
        unit.Element = "ice";
    }
    public void HandleEnemyTurn()
    {
        
        enemySkill.Action();
        
    }


    
}
