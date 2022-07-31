using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private string[] elemental = {"none","fire","ice","thunder","wind"};
    private string element;
    private int damage;
    private int maxHp;
    private int currentHp;

    public int Damage
    {
        get
        {
            return damage;
        }
        set 
        {
            damage = value;
        }
    }
    public int MaxHp
    {
        get 
        {
            return maxHp;
        }
        set
        {
            maxHp = value;
        }

    }
    public int CurrentHp
    {
        get
        {
            return currentHp;
        }
        set
        {
            currentHp = value;
        }
    }

    public string Element
    {
        get
        {
            return element;
        }
        set
        {
            element = value;
            for(int i = 0; i < elemental.Length; i++)
            {
                //Debug.Log("check element " + elemental[i]+ " "+element);
                if (element == elemental[i]) return;
            }
            element = "none";
        }
    }

    public bool TakeDamage(int dmg)
    {
        currentHp -= dmg;

        if (currentHp <= 0) return true;
        else return false;
    }

    public void Healpoint(int point)
    {
        currentHp += point;
        if (currentHp >= maxHp) currentHp = maxHp;
    }

}
