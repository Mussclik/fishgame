using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private int listOffset = 0;
    public bool open;
    static bool firstload = true;
    [SerializeField] GameObject unitPrefab;
    [SerializeField] Transform[] unitPositions = new Transform[4];
    [SerializeField] GameObject shop;
    [SerializeField] List<GameObject> units;
    [SerializeField] List<ItemInfo> items;
    [SerializeField] List<FishRodInfo> rods;
    [SerializeField] List<Sprite> sprites;
    [SerializeField] MovementScript script;


    public void Start()
    {
        //if (firstload)
        //{
            foreach (FishRodInfo rod in rods) // this causes problems everytime the scene is loaded
            {
                items.Add(rod);
            }
        //    firstload = false;
        //}


        int temp = 0;

        for (int i = 0; i < items.Count; i++)
        {
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
            temp += 1;
        }
        UpdateSelection();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            PlayerInfo.money += 500;
        }
    }
    public void Open()
    {
        script.stopped = true;
        open = true;
        listOffset = 0;
        Time.timeScale = 0;
        shop.SetActive(true);
    }
    public void Close()
    {
        script.stopped = false;
        open = false;
        Time.timeScale = 1;
        shop.SetActive(false);

    }
    public void Buy(StoreUnit storeunit, int currentplayermoney)
    {
        if (!storeunit.isPurchased && currentplayermoney >= storeunit.item.price)
        {
            storeunit.isPurchased = true;
            storeunit.bought.enabled = true;
            storeunit.item.Buy();

            // Additional code to handle the removal of the bought item from the list
            units.Remove(storeunit.gameObject);
            Debug.Log("Deleting " + storeunit.gameObject.name);
            Destroy(storeunit.gameObject);
        }
    }


    public void ButtonBuy(int button)
    {
        List<GameObject> unitlist = UpdateSelection();

        if (button < unitlist.Count)
        {
            Buy(unitlist[button].GetComponent<StoreUnit>(), PlayerInfo.money);
        }

        UpdateSelection();
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
    public List<GameObject> UpdateSelection()
    {
        List<GameObject> newlist = new List<GameObject>();

        foreach (GameObject unit in units)
        {
            unit.GetComponent<StoreUnit>().UpdateInfo();
            unit.SetActive(false);
        }

        for (int i = 0; i < 4; i++)
        {
            int index = listOffset + i;
            if (index < units.Count && !units[index].GetComponent<StoreUnit>().isPurchased)
            {
                units[index].SetActive(true);
                newlist.Add(units[index]);
            }
        }

        return newlist;
    }



}
