using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //private string[] elemental = {"None","Fire","Ice","Thunder","Wind"};
    private string element;
    private string weakness;
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
            
        }
    }public string Weakness
    {
        get
        {
            return weakness;
        }
        set
        {
            weakness = value;
            
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
