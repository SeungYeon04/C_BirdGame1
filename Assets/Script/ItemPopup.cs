using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPopup : MonoBehaviour
{
    public Image itemImage; // ������ �̹����� ǥ���� UI �̹���
    public Text itemQuantityText; // ������ ������ ǥ���� �ؽ�Ʈ

    public void Setup(Item item, int quantity)
    {
        itemImage.sprite = item.itemImage; // ������ �̹��� ����
        itemQuantityText.text = $"{quantity}"; // ������ ���� ����(����) 
        StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator FadeOutAndDestroy()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        float duration = 1f; // �˾��� ������� �ð�
        float elapsed = 0f;

        Vector3 startPosition = transform.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            canvasGroup.alpha = 1f - t; // ���� ��������
            transform.position = startPosition + Vector3.up * t; // ���� �ö�

            yield return null;
        }

        Destroy(gameObject);
    }
}