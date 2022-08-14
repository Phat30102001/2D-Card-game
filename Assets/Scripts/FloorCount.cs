using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloorCount : MonoBehaviour
{
    private TextMeshProUGUI floorCount;
    private GameObject floor;

    private void Awake()
    {
        floor = GameObject.Find("Floor");
        floorCount = floor.GetComponent<TextMeshProUGUI>();
    }
    public void Count(int count)
    {
        floorCount.text = "Floor clear: " + count;
    }
}
