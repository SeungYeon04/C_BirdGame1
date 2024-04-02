using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public Item item;
    public int quantity;

    public ItemSlot(Item newItem, int newQuantity)
    {
        item = newItem;
        quantity = newQuantity;
    }

    // ������ �߰��ϴ� �޼ҵ�. �ִ�ġ�� ���� �ʵ��� Ȯ��.
    public void AddQuantity(int amount)
    {
        quantity = Mathf.Min(quantity + amount, 99);
    }
}

public class Inventory : MonoBehaviour
{
    // �κ��丮�� ������ ������ ���� ����Ʈ
    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    // �κ��丮�� ������ ������ ����Ʈ
    public List<Item> items;

    // ���Ե��� �θ� ��ü
    [SerializeField]
    private Transform slotParent;

    // ���� �迭
    [SerializeField]
    private Slot[] slots;

     #if UNITY_EDITOR
    // ������ �󿡼��� ȣ��Ǵ� �Լ�
    private void OnValidate()
    {
        // ���� �迭�� �θ� ��ü �Ʒ��� ��� Slot ������Ʈ�� �ʱ�ȭ
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
     #endif

    void Awake()
    {
        // �κ��丮 �ʱ�ȭ �Լ� ȣ��
        FreshSlot();
    }

    // �������� �߰��ϴ� �Լ�
    public void AddItem(Item itemToAdd)
    {
        // �ش� �������� ���� ������ ã��
        ItemSlot slot = itemSlots.Find(s => s.item == itemToAdd);

        if (slot != null)
        {
            // ������ �̹� ������, ������ ����
            slot.AddQuantity(1);
        }
        else
        {
            // �� ������ �߰�
            if (itemSlots.Count < slots.Length)
            {
                itemSlots.Add(new ItemSlot(itemToAdd, 1));
            }
            else
            {
                Debug.LogWarning("������ ���� �� �ֽ��ϴ�.");
                return;
            }
        }

        FreshSlot();
    }

    public void FreshSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < itemSlots.Count)
            {
                slots[i].item = itemSlots[i].item; // ������ �Ҵ�
                slots[i].quantity = itemSlots[i].quantity; // ���� �Ҵ�
            }
            else
            {
                slots[i].item = null; // ������ ����
                slots[i].quantity = 0; // ���� ����
            }
        }
    }

}
