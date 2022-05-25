using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public List<ItemGeneric> itemList;
    public List<Image> icons;
    public bool isFull;
    
    private int inventorySize;

    private void Awake()
    {
        inventorySize = transform.childCount;
        itemList = new List<ItemGeneric>{};
        icons = new List<Image>{};
        
        Instance = this;
    }
    private void Start()
    {
        for(int a = 0; a < inventorySize; a++)
        {
            icons.Add(transform.GetChild(a).GetComponent<Image>());
        }
    }
    public void AddItem(ItemGeneric generic)
    {
        print(generic.icon.name);
        if(itemList.Count < inventorySize)
        {
            itemList.Add(generic);
            icons[itemList.Count-1].sprite = generic.icon;
        }
        if(itemList.Count >= inventorySize)
        {
            isFull = true;
        }
        print("add " + generic.itemType);
    }
}
