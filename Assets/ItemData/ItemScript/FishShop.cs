// 생선가게 스크립트 예시
using static Item;
using UnityEngine;

public class FishShop : MonoBehaviour
{
    public Inventory inventory; // 인벤토리 참조
    public GameObject InventoryScrin; 

    // 생선 판매 버튼 클릭 시 호출
    public void OnSellFishButtonClick()
    {
        Debug.Log("생선가게모드");
        inventory.EnableSaleMode(ItemType.Fish); // 인벤토리를 생선 판매 모드로 전환 
        InventoryScrin.SetActive(true); 
    }


}
