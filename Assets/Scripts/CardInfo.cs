using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour
{
    private Card card;
    // Start is called before the first frame update
    void Awake()
    {

        card = Resources.Load<Card>("Prefabs/Cards/Fire");

        // check card type
        System.Random random = new System.Random();
        if (card.cardName != "Heal")
        {
            card.AttackPoint = random.Next(1, 6);
        }
        else if (card.cardName == "Heal")
        {
            card.HealPoint = random.Next(1, 5);
        }


    }

    
}
