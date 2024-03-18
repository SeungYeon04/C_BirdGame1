using UnityEngine;

public class TouchPadInput : MonoBehaviour
{
    // �÷��̾� �̵� �ӵ�
    public float moveSpeed = 5f;
    // �÷��̾��� ��ǥ ��ġ
    private Vector3 targetPosition;
    // �̵� ������ ����
    private bool isMoving = false;

    void Update()
    {
        // ��ġ �Է� �Ǵ� ���콺 �Է� ����
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // ��ġ �Է��� �ִ� ���
            if (Input.touchCount > 0)
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = transform.position.z; // �÷��̾��� Z�� ��ġ ���� 
                CheckAndHandleItem(targetPosition);
            }
            // ���콺 �Է��� �ִ� ���
            else if (Input.GetMouseButtonDown(0))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = transform.position.z; // �÷��̾��� Z�� ��ġ ����
                CheckAndHandleItem(targetPosition);
            }

            // �̵� ����
            isMoving = true;
        }

        // �÷��̾ ��ǥ ��ġ�� �̵�
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // �÷��̾ ��ǥ ��ġ�� �������� �� �̵� ����
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                Debug.Log("����!");
                isMoving = false;
            }
        }
    }

    // �������� ��ġ�� ��ġ���� �����Ͽ� ó��
    void CheckAndHandleItem(Vector3 touchPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

        Debug.Log("����ĳ��Ʈ�� �߻��� ��ġ: " + touchPosition);
        Debug.Log("����ĳ��Ʈ ���: " + hit.collider);

        if (hit.collider != null && hit.collider.CompareTag("Item"))
        {
            Debug.Log("�浹�� ������Ʈ �±�: " + hit.collider.tag);

            // �������� ȹ���ϰų� �������� ��ġ�� ��ġ�� �̵��ϴ� ���� �۾��� ����
            Debug.Log("�������� ȹ���߽��ϴ�!");

            // �������� ȹ���� �Ŀ��� �������� �����ϰų� ��Ȱ��ȭ�� �� �ֽ��ϴ�.
            Destroy(hit.collider.gameObject);
        }

    }
}
