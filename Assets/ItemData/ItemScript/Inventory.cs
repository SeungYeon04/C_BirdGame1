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

    // 수량을 추가하는 메소드. 최대치를 넘지 않도록 확인.
    public void AddQuantity(int amount)
    {
        quantity = Mathf.Min(quantity + amount, 99);
    }
}

public class Inventory : MonoBehaviour
{
    // 인벤토리에 보유한 아이템 슬롯 리스트
    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    // 인벤토리에 보유한 아이템 리스트
    public List<Item> items;

    // 슬롯들의 부모 객체
    [SerializeField]
    private Transform slotParent;

    // 슬롯 배열
    [SerializeField]
    private Slot[] slots;

     #if UNITY_EDITOR
    // 에디터 상에서만 호출되는 함수
    private void OnValidate()
    {
        // 슬롯 배열을 부모 객체 아래의 모든 Slot 컴포넌트로 초기화
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
     #endif

    void Awake()
    {
        // 인벤토리 초기화 함수 호출
        FreshSlot();
    }

    // 아이템을 추가하는 함수
    public void AddItem(Item itemToAdd)
    {
        // 해당 아이템을 가진 슬롯을 찾음
        ItemSlot slot = itemSlots.Find(s => s.item == itemToAdd);

        if (slot != null)
        {
            // 슬롯이 이미 있으면, 수량을 증가
            slot.AddQuantity(1);
        }
        else
        {
            // 새 슬롯을 추가
            if (itemSlots.Count < slots.Length)
            {
                itemSlots.Add(new ItemSlot(itemToAdd, 1));
            }
            else
            {
                Debug.LogWarning("슬롯이 가득 차 있습니다.");
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
                slots[i].item = itemSlots[i].item; // 아이템 할당
                slots[i].quantity = itemSlots[i].quantity; // 수량 할당
            }
            else
            {
                slots[i].item = null; // 아이템 비우기
                slots[i].quantity = 0; // 수량 리셋
            }
        }
    }

}
