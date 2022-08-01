using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New card", menuName = "Cards")]
public class Card : ScriptableObject
{
    public string cardName;
    public string cardDescription;
    public Sprite cardImage;
    public int attackPoint;
    public int healPoint;
}
