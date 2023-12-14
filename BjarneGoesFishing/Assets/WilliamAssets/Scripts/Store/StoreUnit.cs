using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUnit : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI itemname, description, bought, equipped;
    [SerializeField] public UnityEngine.UI.Image spriterenderer;
    [SerializeField] public Sprite sprite;
    [SerializeField] public ItemInfo item;

    public void UpdateInfo()
    {
        itemname.text = item.name;
        description.text = item.description;
        spriterenderer.sprite = sprite;
        
    }
}
