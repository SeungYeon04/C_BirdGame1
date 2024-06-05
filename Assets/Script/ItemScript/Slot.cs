using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static Inventory;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image; // �̹��� ������Ʈ
    [SerializeField] Text quantityText; // ���� �ؽ�Ʈ ������Ʈ

    public Inventory inventory; // �κ��丮�� ���� ����
    public PlayerStack playerStack; // PlayerStack ��ũ��Ʈ�� ���� ����
    public ItemSlot itemSlot;


    private Item _item;
    private int _quantity; // ������ ���� �ʵ�

    // ������ ������Ƽ
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            UpdateSlotUI(); // UI ������Ʈ �޼ҵ� ȣ��
        }
    }

    // ������ ���� ������Ƽ
    public int quantity
    {
        get { return _quantity; }
        set
        {
            _quantity = value;
            UpdateSlotUI(); // UI ������Ʈ �޼ҵ� ȣ��
        }
    }
    // ������ UI�� ������Ʈ�ϴ� �޼ҵ�
    public void UpdateSlotUI()
    {
        if (_item != null)
        {
            image.sprite = _item.itemImage;
            image.color = new Color(1, 1, 1, 1); // ������ �̹��� Ȱ��ȭ

            // �������� 1�� �̻��� ���� ���� ǥ��
            if (_quantity > 1)
            {
                quantityText.text = _quantity.ToString();
                quantityText.gameObject.SetActive(true);
            }
            else
            {
                quantityText.gameObject.SetActive(false);
            }
        }
        else
        {
            image.color = new Color(1, 1, 1, 0); // ������ �̹��� ��Ȱ��ȭ
            quantityText.gameObject.SetActive(false); // ���� �ؽ�Ʈ ��Ȱ��ȭ
        }
    }


    public void OnClick()
    {
        // Inventory�� PlayerStack ������ ���� ��� ���� �α�
        if (inventory == null)
        {
            Debug.LogError("Inventory ������ �����ϴ�.");
            return;
        }
        if (itemSlot == null)
        {
            Debug.LogError("ItemSlot ������ �����ϴ�.");
            return;
        }

        if (inventory.currentMode == Inventory.InventoryMode.UseItem)
        {
            // ������ ��� ���� (���⼭ ��ü���� ��� ������ �߰��ϰų� ����)
            Debug.Log(item + " ����"); //ItemSlot.ItemName. �� ���ִ� �ǳ� 
        }
        else if(inventory.currentMode == Inventory.InventoryMode.SellItem) // �Ǹ� ������� Ȯ�� && itemSlot.item.itemType == inventory.sellableItemType && inventory.currentMode != Inventory.InventoryMode.UseItem
        {
            // �Ǹ� ���� ����
            inventory.SellItem(item, 1);
            Debug.Log("�Ǹŷ��� �����");
        }
        else
        {
            Debug.Log("����� �Ǹ��� �� ���� ����Դϴ�.");
        }
    }


    public void UpdateSlot(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
        // �̰����� UI ������Ʈ(��: ������ �̹���, ���� �ؽ�Ʈ ��)�� ������Ʈ�ϴ� ���� ����
    }

    public void ClearSlot()
    {
        this.item = null;
        this.quantity = 0;
        // �̰����� UI ������Ʈ�� "���" ���·� ����� ���� ����
    }


}
