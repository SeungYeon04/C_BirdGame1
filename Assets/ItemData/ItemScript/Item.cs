using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC,
        Fruit, // 과일
        Fish,  // 생선
    }

    public string itemName; //아이템의 이름 
    public ItemType itemType; //아이템 유형 
    public Sprite itemImage; //아이템의 이미지 
    public GameObject itemPrefab; //아이템의 프리팹(아이템 생성시 프리팹으로 찍어냄) 
    public int value; // 아이템의 가치 (판매 가격)


    public string weaponType; //무기형 

}
