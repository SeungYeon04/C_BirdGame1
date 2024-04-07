using UnityEngine;
using UnityEngine.UI;

public class PlayerStack : MonoBehaviour
{

    // 플레이어의 돈을 저장하는 프로퍼티
    public int Money { get; private set; }

    // 돈을 표시할 UI 요소
    public Text PlayerMoneyText;

    public static PlayerStack Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스 제거
        }
    }


    private void Start()
    {
        // 시작 시 돈의 UI를 초기화
        UpdateMoneyUI();
    }

    // 돈을 추가하는 메서드
    public void AddMoney(int amount)
    {
        Money += amount;
        UpdateMoneyUI(); // UI 업데이트
    }

    // 돈을 차감하는 메서드
    public void SubtractMoney(int amount)
    {
        Money = Mathf.Max(0, Money - amount); // 돈이 음수가 되지 않도록 보장
        UpdateMoneyUI(); // UI 업데이트
    }

    // 돈과 관련된 UI를 업데이트하는 메서드
    private void UpdateMoneyUI()
    {
        if (PlayerMoneyText != null)
        {
            PlayerMoneyText.text = $"Money: {Money}";
        }
    }
}
