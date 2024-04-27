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

    //�޴� ��ġ�� â �ݱ� 

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

    //�޴� �� ��ư�� 

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
        Debug.Log("���� �⺻ ���: " + inventory.currentMode.ToString());

    }

    public void InventoryBack()
    {
        InventoryScrin.SetActive(false);

        //inventory.EnableUseItemMode(); 
        inventory.currentMode = Inventory.InventoryMode.UseItem;
        Debug.Log("���� �⺻ ���: " + inventory.currentMode.ToString());
    }
}
