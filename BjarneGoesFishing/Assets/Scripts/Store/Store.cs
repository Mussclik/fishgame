using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private int listOffset = 0;
    [SerializeField] GameObject unitPrefab;
    [SerializeField] Transform[] unitPositions = new Transform[4];
    [SerializeField] GameObject shop;
    [SerializeField] List<GameObject> units;
    [SerializeField] List<ItemInfo> items;
    [SerializeField] List<Sprite> sprites;
    [SerializeField] List<Sprite> fishrodInfo;
    [SerializeField] List<UnityEngine.UI.Button> arrows;
    [SerializeField] List<UnityEngine.UI.Button> buttons;

    public void Start()
    {
        int temp = 0;
        Debug.Log(items.Count);
        for (int i = 0; i < items.Count; i++)
        {
            temp += 1;
            if (temp > 3)
            {
                temp = 0;
            }

            GameObject newUnit = Instantiate(unitPrefab, unitPositions[temp].position, Quaternion.identity, shop.transform);
            StoreUnit unitIteminfo = newUnit.GetComponent<StoreUnit>();
            Debug.Log((unitIteminfo == null) + " " + (unitIteminfo?.item == null) + " " + i);
            unitIteminfo.item = items[i];
            unitIteminfo.sprite = sprites[i];
            unitIteminfo.UpdateInfo();

            units.Add(newUnit);
        }
        UpdateSelection();
    }
    public void Open()
    {
        listOffset = 0;
        Time.timeScale = 0;
        shop.SetActive(true);
    }
    public void Close()
    {
        Time.timeScale = 1;
        shop.SetActive(false);

    }
    public void Buy(StoreUnit storeunit, int currentplayermoney)
    {
        if (currentplayermoney > storeunit.item.price)
        {
            storeunit.bought.enabled = true;
        }
    }
    public void Next()
    {
        if (units[listOffset + 1] != null)
        {
            listOffset += 4;
            UpdateSelection();
        }
    }
    public void Previous()
    {
        if (listOffset > 0)
        {
            listOffset -= 4;
            UpdateSelection();
        }

    }
    public void UpdateSelection()
    {
        foreach (GameObject unit in units)
        {
            unit.SetActive(false);
        }
        for (int i = 0; i < 4; i++)
        {
            if (units[listOffset + i] != null)
            {
                units[listOffset + i].SetActive(true);
            }
        }
    }



}
