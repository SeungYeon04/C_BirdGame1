using UnityEngine;

public class TouchPadInput : MonoBehaviour
{
    // 플레이어 이동 속도
    public float moveSpeed = 5f;
    // 플레이어의 목표 위치
    private Vector3 targetPosition;
    // 이동 중인지 여부
    private bool isMoving = false;

    // 플레이어의 인벤토리
    public Inventory inventory;

    void Update()
    {
        // 터치 입력 또는 마우스 입력 감지
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // 터치 입력이 있는 경우
            if (Input.touchCount > 0)
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = transform.position.z; // 플레이어의 Z축 위치 유지 
                CheckAndHandleItem(targetPosition);
            }
            // 마우스 입력이 있는 경우
            else if (Input.GetMouseButtonDown(0))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = transform.position.z; // 플레이어의 Z축 위치 유지
                CheckAndHandleItem(targetPosition);
            }

            // 이동 시작
            isMoving = true;
        }

        // 플레이어를 목표 위치로 이동
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 플레이어가 목표 위치에 도달했을 때 이동 중지
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                Debug.Log("도착!");
                isMoving = false;
            }
        }
    }

    // 아이템을 터치한 위치에서 검출하여 처리
    void CheckAndHandleItem(Vector3 touchPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Item"))
        {
            // 아이템을 획득하거나 아이템을 터치한 위치로 이동하는 등의 작업을 수행
            Debug.Log("아이템을 획득했습니다!");

            // 아이템을 획득한 후에는 아이템을 삭제하거나 비활성화할 수 있습니다.
            Destroy(hit.collider.gameObject);

            IObjectItem clickInterface = hit.transform.gameObject.GetComponent<IObjectItem>();

            if (clickInterface != null)
            {
                // 클릭한 객체에서 아이템 정보를 가져옴
                Item item = clickInterface.ClickItem();
                // 아이템 이름 출력
                print($"{item.itemName}");
                // 인벤토리에 아이템 추가
                inventory.AddItem(item);
                Debug.Log(item);
           
            }
        }
    }
}
