using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    TextMeshProUGUI textmeshpro;

    private void Start()
    {
        textmeshpro = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        textmeshpro.text = $"Money: {PlayerInfo.money}";
    }
}
