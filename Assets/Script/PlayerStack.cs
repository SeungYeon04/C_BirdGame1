using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class PlayerStack : MonoBehaviour
{
    public static PlayerStack Instance;
    public Text PlayerMoneyText;
    public int Money { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadMoney();  // �ʱ� �� �ε�
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        UpdateMoneyUI();
        SaveMoney();
    }

    public void SubtractMoney(int amount)
    {
        Money = Mathf.Max(0, Money - amount);
        UpdateMoneyUI();
        SaveMoney();
    }

    private void UpdateMoneyUI()
    {
        if (PlayerMoneyText != null)
        {
            PlayerMoneyText.text = "Money: " + Money;
        }
    }

    public void SaveMoney()
    {
        PlayerData data = new PlayerData(Money);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // LoadMoney() ���� �����ڸ� public���� ����
    public void LoadMoney()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Money = data.money;
            UpdateMoneyUI();
        }
    }
}

