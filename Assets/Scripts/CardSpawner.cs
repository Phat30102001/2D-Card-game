using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject card;
    GameObject newCard;

    public static CardSpawner instance;

    public string gameObjectName;

    private void Awake()
    {
        instance = this;
    }

    public void HandleSpawnCard()
    {   
        System.Random random = new System.Random();

        int cardPrefab = random.Next(1,9);
        if (cardPrefab != 5 && cardPrefab > 5) cardPrefab -= 5;

        card = Resources.Load<GameObject>("Prefabs/Cards/"+cardPrefab);


        //spawn card, object name's card
        gameObjectName = "Card" ;
        newCard=Instantiate(card);
        newCard.name = gameObjectName;

        //make card game object create inside father game object (CardInHand)
        newCard.transform.SetParent(GameObject.FindGameObjectWithTag("CardOnHand").transform,false);




    }



    
}
