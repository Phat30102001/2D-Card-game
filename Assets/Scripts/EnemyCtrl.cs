using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private EnemySkill enemySkill;
    public Unit unit;

    private string[] element = { "Fire", "Ice", "Thunder", "Wind" };

    void Awake()
    {
        int elementNum = 0;
        int weaknessNum = 0;
        
        enemySkill = GameObject.Find("EnemyPrefab").GetComponent<EnemySkill>();
        unit = Resources.Load<Unit>("Prefabs/EnemyUnit");

        System.Random random = new System.Random();


        unit.Damage = random.Next(2,4);
        unit.MaxHp = random.Next(8, 15);
        unit.CurrentHp = unit.MaxHp;

        

        while (elementNum == weaknessNum) {
            elementNum = random.Next(0, 4); 
            weaknessNum = random.Next(0, 4);
        }

        unit.Element = element[elementNum];
        unit.Weakness = element[weaknessNum];
        //Debug.Log(elementNum);
    }
    public void HandleEnemyTurn()
    {
        
        enemySkill.Action();
        
    }


    
}
