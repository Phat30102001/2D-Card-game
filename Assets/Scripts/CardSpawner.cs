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
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {   
        System.Random random = new System.Random();

        int cardPrefab = random.Next(1,5);

        card = Resources.Load<GameObject>("Prefabs/Cards/"+cardPrefab);

        //Debug.Log(cardPrefab);


        //spawn card

        
        
        
        gameObjectName = "Card" ;
        newCard=Instantiate(card);
        newCard.name = gameObjectName;

        //make card game object create inside father game object (CardInHand)
        newCard.transform.SetParent(GameObject.FindGameObjectWithTag("CardOnHand").transform,false);

        yield return new WaitForSeconds(0.1f);


    }



    
}
