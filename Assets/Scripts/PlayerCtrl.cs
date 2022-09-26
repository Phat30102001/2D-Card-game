using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Unit unit;
    public void StatGen()
    {
        unit = Resources.Load<Unit>("Prefabs/Player");

        unit.MaxHp = 20;
        unit.CurrentHp = unit.MaxHp;
        unit.Element = "none";

    }
}
