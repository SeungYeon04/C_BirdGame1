using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
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

    // 슬롯을 새로고침하는 함수
    public void FreshSlot()
    {
        int i = 0;
        // 아이템 리스트와 슬롯 배열의 길이 중 작은 값까지 반복하여 슬롯에 아이템 할당
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        // 남은 슬롯은 비움
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    // 아이템을 추가하는 함수
    public void AddItem(Item _item)
    {
        // 아이템 리스트의 길이가 슬롯 배열의 길이보다 작은 경우에만 아이템 추가
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            // 아이템 추가 후 슬롯 새로고침
            FreshSlot();
            Debug.Log("아이템을 추가했습니다.");
        }
        else
        {
            // 슬롯이 가득 찬 경우 경고 메시지 출력
            print("슬롯이 가득 차 있습니다. ");
        }
    }
}
