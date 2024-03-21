using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectItem : MonoBehaviour, IObjectItem
{
    [Header("������")] 
    public Item Item;

    [Header("������ �̹���")] 
    public SpriteRenderer itemImage; 

    void Start()
    {
        itemImage.sprite = Item.itemImage; 
    }

    public Item ClickItem()
    {
        return this.Item; 
    }

}
