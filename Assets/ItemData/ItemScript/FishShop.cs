// �������� ��ũ��Ʈ ����
using static Item;
using UnityEngine;

public class FishShop : MonoBehaviour
{
    public Inventory inventory; // �κ��丮 ����
    public GameObject InventoryScrin; 

    // ���� �Ǹ� ��ư Ŭ�� �� ȣ��
    public void OnSellFishButtonClick()
    {
        Debug.Log("�������Ը��");
        inventory.EnableSaleMode(ItemType.Fish); // �κ��丮�� ���� �Ǹ� ���� ��ȯ 
        InventoryScrin.SetActive(true); 
    }


}
