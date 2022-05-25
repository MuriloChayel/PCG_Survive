using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemGeneric : ScriptableObject
{
    public Sprite icon;
    public enum type
    {
        seed = 0,
        item = 1,
    }
    public type itemType;
}
