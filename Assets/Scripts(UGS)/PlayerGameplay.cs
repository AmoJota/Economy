using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerGameplay : MonoBehaviour
{
    [SerializeField] TMP_Text userText;

    private void Start()
    {
        string temp = PlayerPrefs.GetString("UserName");
        userText.text = "Usuario: " + temp;
    }
}
