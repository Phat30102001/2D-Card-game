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
        enemySkill = GameObject.Find("EnemyPrefab").GetComponent<EnemySkill>();
        unit = Resources.Load<Unit>("Prefabs/EnemyUnit");

        System.Random random = new System.Random();


        unit.Damage = random.Next(2,4);
        unit.MaxHp = random.Next(8, 21);
        unit.CurrentHp = unit.MaxHp;

        int elementNum = random.Next(0, 4);

        unit.Element = element[elementNum];
        //Debug.Log(elementNum);
    }
    public void HandleEnemyTurn()
    {
        
        enemySkill.Action();
        
    }


    
}
