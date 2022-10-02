using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageNotify : MonoBehaviour
{
    private TextMeshProUGUI message;

    private void Awake()
    {
        message = GameObject.Find("Message").GetComponent<TextMeshProUGUI>();
    }
    public void ShowMessage(string mess)
    {
        message.text = mess;
    }

    
}
