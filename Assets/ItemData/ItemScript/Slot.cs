using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static Inventory;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image; // 이미지 컴포넌트
    [SerializeField] Text quantityText; // 수량 텍스트 컴포넌트

    public Inventory inventory; // 인벤토리에 대한 참조
    public PlayerStack playerStack; // PlayerStack 스크립트에 대한 참조
    public ItemSlot itemSlot;


    private Item _item;
    private int _quantity; // 아이템 수량 필드

    // 아이템 프로퍼티
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            UpdateSlotUI(); // UI 업데이트 메소드 호출
        }
    }

    // 아이템 수량 프로퍼티
    public int quantity
    {
        get { return _quantity; }
        set
        {
            _quantity = value;
            UpdateSlotUI(); // UI 업데이트 메소드 호출
        }
    }

    // 슬롯의 UI를 업데이트하는 메소드
    private void UpdateSlotUI()
    {
        if (_item != null)
        {
            image.sprite = _item.itemImage;
            image.color = new Color(1, 1, 1, 1); // 아이템 이미지 활성화

            // 아이템이 1개 이상일 때만 수량 표시
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
            image.color = new Color(1, 1, 1, 0); // 아이템 이미지 비활성화
            quantityText.gameObject.SetActive(false); // 수량 텍스트 비활성화
        }
    }


    public void OnClick()
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory 참조가 없습니다.");
            return;
        }
        if (itemSlot == null)
        {
            Debug.LogError("ItemSlot 참조가 없습니다.");
            return;
        }

        if (inventory.currentMode == Inventory.InventoryMode.SellItem && itemSlot.item.itemType == inventory.sellableItemType)
        {
            // 아이템 판매 로직
            inventory.SellItem(itemSlot.item, 1);
            Debug.Log("판매로직");
        }
        else if (inventory.currentMode == Inventory.InventoryMode.UseItem)
        {
            // 아이템 사용 로직
            // 예: Debug.Log(itemSlot.item.itemName + " 사용됨"); 
        }
    }

    public void UpdateSlot(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
        // 이곳에서 UI 컴포넌트(예: 아이템 이미지, 수량 텍스트 등)를 업데이트하는 로직 구현
    }

    public void ClearSlot()
    {
        this.item = null;
        this.quantity = 0;
        // 이곳에서 UI 컴포넌트를 "비움" 상태로 만드는 로직 구현
    }


}
