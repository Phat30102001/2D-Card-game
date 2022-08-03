using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    private Card card;

    private TextMeshProUGUI cardName;
    private TextMeshProUGUI cardDescripttion;
    private Image cardImage;

    private void Awake()
    {
        cardName = GameObject.Find("CardName").GetComponent<TextMeshProUGUI>();
        cardDescripttion = GameObject.Find("CardDescription").GetComponent<TextMeshProUGUI>();
        cardImage = GameObject.Find("CardImage").GetComponent<Image>();

        card = Resources.Load<Card>("Prefabs/Cards/Fire");
    }

    // Start is called before the first frame update
    void Start()
    {
        cardName.text = card.cardName;

        // check card type
        if (card.cardName != "Heal")
        {
            cardDescripttion.text = "Deal " +card.AttackPoint+ " "+card.cardName+ " damage";
        }
        else if (card.cardName == "Heal")
        {
            cardDescripttion.text = "Restore "+card.HealPoint+" health point";
        }
        
        cardImage.sprite = card.cardImage;
    }

    
}
