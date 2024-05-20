using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRandomizer : MonoBehaviour
{
    public static FishRandomizer Instance;

    // 각 물고기에 대한 확률을 저장하는 딕셔너리
    private Dictionary<string, int> fishChances = new Dictionary<string, int>
    {
        { "FishA-1", 50 }, // 50% 확률
        { "FishB-1", 30 }, // 30% 확률
        { "FishB-2", 20 }  // 20% 확률
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

    // 물고기를 잡는 메서드
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
