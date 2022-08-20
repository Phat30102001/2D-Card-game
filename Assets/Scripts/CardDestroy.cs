using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDestroy : MonoBehaviour
{
    public GameObject cardOnHand;

    private void Awake()
    {
        cardOnHand = GameObject.Find("CardOnHand");
    }
    public void DestroyCard(GameObject gameObject)
    {
        Destroy(gameObject);
    }
    public void DestroyAllCard()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject card = cardOnHand.transform.GetChild(i).gameObject;
            
            DestroyCard(card);
        }
        
        
        
    }
}
