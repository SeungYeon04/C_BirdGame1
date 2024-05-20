using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRandomizer : MonoBehaviour
{
    public static FishRandomizer Instance;

    // �� ����⿡ ���� Ȯ���� �����ϴ� ��ųʸ�
    private Dictionary<string, int> fishChances = new Dictionary<string, int>
    {
        { "FishA-1", 50 }, // 50% Ȯ��
        { "FishB-1", 30 }, // 30% Ȯ��
        { "FishB-2", 20 }  // 20% Ȯ��
    };

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
    }

    // ����⸦ ��� �޼���
    public void CatchFish()
    {
        int randomValue = Random.Range(0, 100);
        int cumulative = 0;

        foreach (var fish in fishChances)
        {
            cumulative += fish.Value;
            if (randomValue < cumulative)
            {
                Debug.Log($"Caught {fish.Key}");
                return;
            }
        }

        Debug.Log("No fish caught.");
    }
}
