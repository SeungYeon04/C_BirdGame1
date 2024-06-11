using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPopup : MonoBehaviour
{
    public Image itemImage; // 아이템 이미지를 표시할 UI 이미지
    public Text itemQuantityText; // 아이템 수량을 표시할 텍스트

    public void Setup(Item item, int quantity)
    {
        itemImage.sprite = item.itemImage; // 아이템 이미지 설정
        itemQuantityText.text = $"{quantity}"; // 아이템 수량 설정(띄우기) 
        StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator FadeOutAndDestroy()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        float duration = 1f; // 팝업이 사라지는 시간
        float elapsed = 0f;

        Vector3 startPosition = transform.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            canvasGroup.alpha = 1f - t; // 점점 투명해짐
            transform.position = startPosition + Vector3.up * t; // 위로 올라감

            yield return null;
        }

        Destroy(gameObject);
    }
}