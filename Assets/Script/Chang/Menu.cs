using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Inventory;
using static Item;

public class Menu : MonoBehaviour
{
    public Inventory inventory; 
    public Slot slot; 

    public GameObject MenuScrin;
    public GameObject MyStatsScrin;
    public GameObject InventoryScrin; 

    //메뉴 터치와 창 닫기 

    public void MenuBtn()
    {
        MenuScrin.SetActive(true);
    }

    public void MenuBackBtn()
    {
        MenuScrin.SetActive(false);
    }

    public void BackStats()
    {
        MyStatsScrin.SetActive(false);
        InventoryScrin.SetActive(false);
    }

    //메뉴 내 버튼들 

    public void MenuMyStats()
    {
        MenuScrin.SetActive(false);
        MyStatsScrin.SetActive(true);
    }

    public void MenuATM()
    {
        SceneManager.LoadScene("ATM");
    }

    public void InventoryOpen()
    {
        InventoryScrin.SetActive(true);

        //inventory.EnableUseItemMode();
        inventory.currentMode = Inventory.InventoryMode.UseItem;
        Debug.Log("현재 기본 모드: " + inventory.currentMode.ToString());

    }

    public void InventoryBack()
    {
        InventoryScrin.SetActive(false);

        //inventory.EnableUseItemMode(); 
        inventory.currentMode = Inventory.InventoryMode.UseItem;
        Debug.Log("현재 기본 모드: " + inventory.currentMode.ToString());
    }
}
