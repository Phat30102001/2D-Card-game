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

    public void HandleSpawnCard(int i)
    {
        // case 1 is for spawn card normal card which spawned at the start of player turn
        // case 2 is for spawn unknow card which is one of enemy skill
        switch (i)
        {
            case 1:
                SpawnNormalCard();
                break;
            case 2:
                SpawnUnknowCard();
                break;
        }
        //System.Random random = new System.Random();

        //// random card, heal card have lower chance to spawn
        //int cardPrefab = random.Next(1,9);
        //if (cardPrefab != 5 && cardPrefab > 5) cardPrefab -= 5;

        //card = Resources.Load<GameObject>("Prefabs/Cards/"+cardPrefab);

        //spawn card, object name's card
        gameObjectName = "Card" ;
        newCard=Instantiate(card);
        newCard.name = gameObjectName;

        //make card game object create inside father game object (CardInHand)
        newCard.transform.SetParent(GameObject.FindGameObjectWithTag("CardOnHand").transform,false);

    }
    private void SpawnNormalCard()
    {
        System.Random random = new System.Random();

        // random card, heal card have lower chance to spawn
        int cardPrefab = random.Next(1, 9);
        if (cardPrefab != 5 && cardPrefab > 5) cardPrefab -= 5;

        card = Resources.Load<GameObject>("Prefabs/Cards/" + cardPrefab);
    }
    private void SpawnUnknowCard()
    {
        card = Resources.Load<GameObject>("Prefabs/Cards/" + 6);
    }



}
