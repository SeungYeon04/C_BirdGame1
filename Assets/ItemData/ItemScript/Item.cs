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
        Fruit, // ����
        Fish,  // ����
    }

    public string itemName; //�������� �̸� 
    public ItemType itemType; //������ ���� 
    public Sprite itemImage; //�������� �̹��� 
    public GameObject itemPrefab; //�������� ������(������ ������ ���������� ��) 
    public int value; // �������� ��ġ (�Ǹ� ����)


    public string weaponType; //������ 

}
