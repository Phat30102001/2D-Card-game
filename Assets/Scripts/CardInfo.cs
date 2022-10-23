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
        switch (cardName)
        {
            case "Heal":
                healPoint = random.Next(5, 8);
                break;
            //case "Unknow":
            //    UnknowCardGen();
            //    break;
            default:
                attackPoint = random.Next(2, 6);
                break;
        }
        //if (cardName != "Heal")
        //{
        //    attackPoint = random.Next(2,6);
        //}
        //else if (cardName == "Heal")
        //{
        //    healPoint = random.Next(5, 8);
        //}
    }
    public int GetAttackPoint()
    {
        return attackPoint;      
    }

    public int GetHealPoint()
    {
        return healPoint;
    }
    //private void UnknowCardGen()
    //{
    //    string[] element = { "Fire", "Ice", "Thunder", "Wind" };
    //    System.Random random = new System.Random();
    //    int i = random.Next(0,4);
    //    cardName = element[i];
    //    attackPoint = random.Next(2, 6);

    //}






}
