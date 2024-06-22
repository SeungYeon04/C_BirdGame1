using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Inventory inventory;

    // 저장할 파일 경로
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
        // inventoryFilePath 초기화
        inventoryFilePath = Path.Combine(Application.persistentDataPath, "inventory.json");

        LoadInventory();
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerStack.Instance?.LoadMoney();
        LoadInventory(); // 씬이 로드될 때 인벤토리 데이터 로드
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

    public void SaveInventory() //인벤토리는 비활성화라 null임. 그래서 inventory !=였나 없앰 
    {
        InventoryData data = new InventoryData(inventory.itemSlots);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(inventoryFilePath, json);
        Debug.Log("Save = " + inventoryFilePath);
    }

    public void LoadInventory()
    {
        string json = File.ReadAllText(inventoryFilePath);
        InventoryData data = JsonUtility.FromJson<InventoryData>(json);
        inventory.itemSlots = data.itemSlots;
        inventory.FreshSlot();
        Debug.Log("Inventory loaded from " + inventoryFilePath);
    }
}
