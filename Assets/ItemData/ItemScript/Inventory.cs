using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // �κ��丮�� ������ ������ ����Ʈ
    public List<Item> items;

    // ���Ե��� �θ� ��ü
    [SerializeField]
    private Transform slotParent;

    // ���� �迭
    [SerializeField]
    private Slot[] slots;

     #if UNITY_EDITOR
    // ������ �󿡼��� ȣ��Ǵ� �Լ�
    private void OnValidate()
    {
        // ���� �迭�� �θ� ��ü �Ʒ��� ��� Slot ������Ʈ�� �ʱ�ȭ
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
     #endif

    void Awake()
    {
        // �κ��丮 �ʱ�ȭ �Լ� ȣ��
        FreshSlot();
    }

    // ������ ���ΰ�ħ�ϴ� �Լ�
    public void FreshSlot()
    {
        int i = 0;
        // ������ ����Ʈ�� ���� �迭�� ���� �� ���� ������ �ݺ��Ͽ� ���Կ� ������ �Ҵ�
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        // ���� ������ ���
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    // �������� �߰��ϴ� �Լ�
    public void AddItem(Item _item)
    {
        // ������ ����Ʈ�� ���̰� ���� �迭�� ���̺��� ���� ��쿡�� ������ �߰�
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            // ������ �߰� �� ���� ���ΰ�ħ
            FreshSlot();
            Debug.Log("�������� �߰��߽��ϴ�.");
        }
        else
        {
            // ������ ���� �� ��� ��� �޽��� ���
            print("������ ���� �� �ֽ��ϴ�. ");
        }
    }
}
