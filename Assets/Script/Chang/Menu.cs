using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

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
    }

    public void InventoryBack()
    {
        InventoryScrin.SetActive(false);
    }
}
