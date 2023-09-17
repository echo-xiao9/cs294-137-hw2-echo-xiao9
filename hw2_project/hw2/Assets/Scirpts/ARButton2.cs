using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARButton2 : MonoBehaviour, OnTouch3D
{
    public TextMeshProUGUI messageText;

    public void OnTouch()
    {
        messageText.gameObject.SetActive(true);
        messageText.text = "Button2Pressed";
        print(messageText.text);
    }
}