using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private EnemySkill enemySkill;
    public Unit unit;

    private string[] element = { "Fire", "Ice", "Thunder", "Wind" ,"None"};

    public void HandleEnemyTurn()
    { 
        enemySkill.Choice();      
    }

    public void StateGen()
    {
        //int elementNum = 0;
        //int subElementNum = 5;
        //int weaknessNum = 0;

        enemySkill = GameObject.Find("EnemyPrefab").GetComponent<EnemySkill>();
        unit = Resources.Load<Unit>("Prefabs/EnemyUnit");

        System.Random random = new System.Random();

        unit.Damage = random.Next(2, 4);
        unit.MaxHp = random.Next(8, 15);
        unit.CurrentHp = unit.MaxHp;
        //Debug.Log(unit.Damage+" "+ unit.MaxHp);
        unit.Weakness = "None";
        unit.Element = unit.Weakness;
        while (unit.Element == unit.Weakness)
        {
            unit.Element = element[ElementRoll()];
            unit.Weakness = element[ElementRoll()];
        }
        SubElementGen();
        Debug.Log(unit.Element +" "+ unit.Weakness +" "+ unit.SubElement);
        //unit.Element = element[elementNum];
        //unit.Weakness = element[weaknessNum];
      
    }
    public void SubElementGen()
    {
        //Debug.Log(BattleSystem.instance.score);
        if (LevelIncrease.instance.LevelCheck(0)==false)
        {
            unit.SubElement = element[4];
            return;
        }
        while (unit.SubElement == unit.Element || unit.SubElement == unit.Weakness|| unit.SubElement=="None")
            unit.SubElement =element[ElementRoll()];
    }
    public int ElementRoll()
    {
        System.Random random = new System.Random();
        int num= random.Next(0, 4);
        //Debug.Log(num);
        return num;
    }


}
