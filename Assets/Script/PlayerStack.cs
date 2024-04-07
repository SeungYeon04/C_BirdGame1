using UnityEngine;
using UnityEngine.UI;

public class PlayerStack : MonoBehaviour
{

    // �÷��̾��� ���� �����ϴ� ������Ƽ
    public int Money { get; private set; }

    // ���� ǥ���� UI ���
    public Text PlayerMoneyText;

    public static PlayerStack Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� ����
        }
    }


    private void Start()
    {
        // ���� �� ���� UI�� �ʱ�ȭ
        UpdateMoneyUI();
    }

    // ���� �߰��ϴ� �޼���
    public void AddMoney(int amount)
    {
        Money += amount;
        UpdateMoneyUI(); // UI ������Ʈ
    }

    // ���� �����ϴ� �޼���
    public void SubtractMoney(int amount)
    {
        Money = Mathf.Max(0, Money - amount); // ���� ������ ���� �ʵ��� ����
        UpdateMoneyUI(); // UI ������Ʈ
    }

    // ���� ���õ� UI�� ������Ʈ�ϴ� �޼���
    private void UpdateMoneyUI()
    {
        if (PlayerMoneyText != null)
        {
            PlayerMoneyText.text = $"Money: {Money}";
        }
    }
}
