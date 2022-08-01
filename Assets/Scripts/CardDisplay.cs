using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardDescripttion;
    public Image cardImage;
    // Start is called before the first frame update
    void Start()
    {
        cardName.text = card.cardName;
        cardDescripttion.text = card.cardDescription;
        cardImage.sprite = card.cardImage;
    }

    
}
