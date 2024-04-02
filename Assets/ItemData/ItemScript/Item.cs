using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Eqipment, 
        Used, 
        Ingredient, 
        ETC, 
    }

    public string itemName; //아이템의 이름 
    public ItemType itemType; //아이템 유형 
    public Sprite itemImage; //아이템의 이미지 
    public GameObject itemPrefab; //아이템의 프리팹(아이템 생성시 프리팹으로 찍어냄) 
    //public int count;   // 아이템의 개수

    public string weaponType; //무기형 

}
