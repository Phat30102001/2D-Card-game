using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour
{
    public string cardName;
    public Sprite cardImage;
    public int attackPoint;
    public int healPoint;

    void Awake()
    {

        // check card type
        System.Random random = new System.Random();
        if (cardName != "Heal")
        {
            attackPoint = random.Next(1, 6);
            //GetAttackPoint();

        }
        else if (cardName == "Heal")
        {
            healPoint = random.Next(3, 11);
            //GetHealPoint();
        }

    }

    private void Start()
    {
        
    }

    public int GetAttackPoint()
    {
        //Debug.Log(attackPoint);
        return attackPoint;
       
    }

    public int GetHealPoint()
    {
        return healPoint;
    }







}
