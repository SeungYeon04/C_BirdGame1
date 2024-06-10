using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Inventory inventory;

    // ������ ���� ���
    private string inventoryFilePath;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // inventoryFilePath �ʱ�ȭ
        inventoryFilePath = Path.Combine(Application.persistentDataPath, "inventory.json");

        LoadInventory();
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerStack.Instance?.LoadMoney();
        LoadInventory(); // ���� �ε�� �� �κ��丮 ������ �ε�
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnApplicationQuit()
    {
        SaveInventory();
    }

    public void SaveInventory()
    {
        if (inventory != null)
        {
            InventoryData data = new InventoryData(inventory.itemSlots);
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(inventoryFilePath, json);
            Debug.Log("Inventory saved to�̤� " + inventoryFilePath);
        }
        else
        {
            Debug.LogError("Inventory reference is null. Cannot save inventory.");
        }
    }

    public void LoadInventory()
    {
        if (File.Exists(inventoryFilePath))
        {
            string json = File.ReadAllText(inventoryFilePath);
            InventoryData data = JsonUtility.FromJson<InventoryData>(json);
            inventory.itemSlots = data.itemSlots; 
            inventory.FreshSlot();
            Debug.Log("Inventory loaded from " + inventoryFilePath);
        }
        else
        {
            Debug.Log("No inventory file found at " + inventoryFilePath);
        }
    }
}
