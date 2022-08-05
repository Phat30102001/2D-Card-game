using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject card;
    GameObject newCard;
    

    public string gameObjectName;

    public string gameObjectNameClone { get { return gameObjectName; } }
  

    private void Start()
    {

        CardRandomize();

    }

    private void CardRandomize()
    {
        
    }
    
    public void Spawn(int i)
    {   
        System.Random random = new System.Random();

        int cardPrefab = random.Next(1,5);

        card = Resources.Load<GameObject>("Prefabs/Cards/"+cardPrefab);
        
        //Debug.Log(cardPrefab);


        //spawn card
        
        
        gameObjectName = "Card" +i;
        newCard=Instantiate(card);
        newCard.name = gameObjectName;

        //Debug.Log(gameObjectNameClone);

        //make card game object create inside father game object (CardInHand)
        newCard.transform.SetParent(GameObject.FindGameObjectWithTag("CardOnHand").transform,false);

    }



    
}
