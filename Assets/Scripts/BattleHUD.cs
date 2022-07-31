using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthTextBar;
    string healthTextConvert;


    public void SetHUD(int maxHp,int currentHp)
    {
        healthBar.maxValue = maxHp;
        healthBar.value = currentHp;

        healthTextConvert = healthBar.value.ToString() + "/" + healthBar.maxValue.ToString();
        healthTextBar.text = healthTextConvert;
       
    }

    public void SetHP(int hp)
    {
        healthTextConvert = hp.ToString() + "/" + healthBar.maxValue.ToString();
        healthTextBar.text = healthTextConvert;

        healthBar.value = hp;

    }
}
