using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FishingRod : MonoBehaviour
{
    private Item _item;
    private int _quantity; // 아이템 수량 필드
    public Inventory inventory; 

    public float fishingTime = 3.0f; // 낚시에 걸리는 시간
    //public List<Item> availableFish; // 사용 가능한 물고기 리스트

    public Item itemA1Pish; // A-1Pish 아이템
    public Item itemB1Pish; // B-1Pish 아이템
    public Item itemB2Pish; // B-2Pish 아이템

    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
        }
    }

    public List<ItemSlot> itemSlots = new List<ItemSlot>();


    // 낚시 시작 메서드
    public void StartFishing()
    {
        StartCoroutine(FishingCoroutine());
    }

    // 낚시 처리 코루틴
    IEnumerator FishingCoroutine()
    {
        Debug.Log("낚시 시작, 애니메이션 재생");
        

        int randomNumber = Random.Range(0, 100); // 물고기 리스트에서 랜덤 인덱스

        Debug.Log("랜덤수:" + randomNumber);

        // 일정 시간 대기
        yield return new WaitForSeconds(fishingTime);

        if (randomNumber <= 30)  
        {
            Debug.Log("A-1Pish 잡았습니다!");
            inventory.AddItem(itemA1Pish); // 인벤토리에 아이템 추가
        }
        else if (randomNumber <= 50)  
        {
            Debug.Log("B-1Pish 잡았습니다!");
            inventory.AddItem(itemB1Pish); // 인벤토리에 아이템 추가
        }
        else if (randomNumber <= 100)
        {
            Debug.Log("B-1Pish 잡았습니다!");
            inventory.AddItem(itemB2Pish); // 인벤토리에 아이템 추가
        }
        else  // 나머지 확률
        {
            Debug.Log("슬롯없음"); 
        }
    }
}
