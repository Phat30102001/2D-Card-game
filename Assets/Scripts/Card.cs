using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New card", menuName = "Cards")]
public class Card : ScriptableObject
{   
    
    public string cardName;
    public Sprite cardImage;
    [SerializeField] private int attackPoint;
    [SerializeField] private int healPoint;

    public int AttackPoint { get; set; }
    public int HealPoint { get; set; }
    
}
