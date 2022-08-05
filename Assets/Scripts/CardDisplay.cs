using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private CardInfo cardInfo;

    private TextMeshProUGUI cardName;
    private TextMeshProUGUI cardDescripttion;
    private Image cardImage;

    //private CardSpawner cardSpawner;

    private void Awake()
    {
        GameObject textInfoDescription = transform.GetChild(2).gameObject;
        GameObject textDesDescription = textInfoDescription.transform.GetChild(0).gameObject;

        GameObject textInfoName = transform.GetChild(1).gameObject;
        GameObject textDesName = textInfoName.transform.GetChild(0).gameObject;

        GameObject textDesImage = transform.GetChild(0).gameObject;


        //cardSpawner = FindObjectOfType<CardSpawner>();

        cardName = textDesName.GetComponent<TextMeshProUGUI>();
        cardDescripttion = textDesDescription.GetComponent<TextMeshProUGUI>();
        cardImage = textDesImage.GetComponent<Image>();

        //cardInfo = GameObject.Find("Card0").GetComponent<CardInfo>();

        
    }

    // Start is called before the first frame update
    private void Start()
    {   

        cardInfo = GetComponent<CardInfo>();
        
        cardName.text = cardInfo.cardName;

        // check card type
        if (cardInfo.cardName != "Heal")
        {
            
            cardDescripttion.text = "Deal " +cardInfo.GetAttackPoint()+ " "+cardInfo.cardName+ " damage";
        }
        else if (cardInfo.cardName == "Heal")
        {
            cardDescripttion.text = "Restore "+cardInfo.healPoint+" health point";
        }
        
        cardImage.sprite = cardInfo.cardImage;

        //Debug.Log(cardInfo.gameObject.name);
    }
    /*private void Update()
    {
        Debug.Log("Found");
    }*/


}
