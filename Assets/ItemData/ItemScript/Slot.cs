using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image; // �̹��� ������Ʈ
    [SerializeField] Text quantityText; // ���� �ؽ�Ʈ ������Ʈ

    private Item _item;
    private int _quantity; // ������ ���� �ʵ�

    // ������ ������Ƽ
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            UpdateSlotUI(); // UI ������Ʈ �޼ҵ� ȣ��
        }
    }

    // ������ ���� ������Ƽ
    public int quantity
    {
        get { return _quantity; }
        set
        {
            _quantity = value;
            UpdateSlotUI(); // UI ������Ʈ �޼ҵ� ȣ��
        }
    }

    // ������ UI�� ������Ʈ�ϴ� �޼ҵ�
    private void UpdateSlotUI()
    {
        if (_item != null)
        {
            image.sprite = _item.itemImage;
            image.color = new Color(1, 1, 1, 1); // ������ �̹��� Ȱ��ȭ

            // �������� 1�� �̻��� ���� ���� ǥ��
            if (_quantity > 1)
            {
                quantityText.text = _quantity.ToString();
                quantityText.gameObject.SetActive(true);
            }
            else
            {
                quantityText.gameObject.SetActive(false);
            }
        }
        else
        {
            image.color = new Color(1, 1, 1, 0); // ������ �̹��� ��Ȱ��ȭ
            quantityText.gameObject.SetActive(false); // ���� �ؽ�Ʈ ��Ȱ��ȭ
        }
    }
}
