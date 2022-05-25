using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public Sprite icon;
    public ItemGeneric.type itemType;

    public void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !Inventory.Instance.isFull)
        {
            Inventory.Instance.AddItem(new ItemGeneric { itemType = this.itemType, icon = icon });
            Destroy(gameObject);
        }
        else if (Inventory.Instance.isFull)
        {
            print("Full");
        }
    }
}
